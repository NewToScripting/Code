﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using Inspire;
using Inspire.Services.WeakEventHandlers;
using Transitionals;
using Transitionals.Controls;

namespace PlaylistModule
{
    /// <summary>
    /// Interaction logic for PlaylistControl.xaml
    /// </summary>
    public partial class PlaylistControl : IWeakEventListener , IDisposable
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ObservableCollection<PlaylistElement> Items { get; set; }

        private readonly DispatcherTimer elementTimer;

        private bool HasLoaded;

        public PlaylistControl()
        {
            InitializeComponent();

            elementTimer = new DispatcherTimer();
            elementTimer.Interval = new TimeSpan(0, 0, 5); // Take out once ItemSource event handler is hookedup
            DispatcherTimerTickEventManager.AddListener(elementTimer, this);
            LoadedEventManager.AddListener(this, this);
            Items = new ObservableCollection<PlaylistElement>();

            _firstCommand = ActionICommand.Create(First, canFirst, out m_canFirstChanged);
            _previousCommand = ActionICommand.Create(Previous, canPrevious, out m_canPreviousChanged);
            _nextCommand = ActionICommand.Create(Next, canNext, out m_canNextChanged);
            _lastCommand = ActionICommand.Create(Last, canLast, out m_canLastChanged);
            _playCommand = ActionICommand.Create(Play, canPlay, out m_canPlayChanged);
            _stopCommand = ActionICommand.Create(Stop, canStop, out m_canStopChanged);

            if(InspireApp.IsPlayer)
                elementTimer.Start();
        }

        public ICommand FirstCommand { get { return _firstCommand; } }

        public ICommand PreviousCommand { get { return _previousCommand; } }

        public ICommand NextCommand { get { return _nextCommand; } }

        public ICommand LastCommand { get { return _lastCommand; } }

        public ICommand PlayCommand { get { return _playCommand; } }

        public ICommand StopCommand { get { return _stopCommand; } }

        void PlaylistControl_Loaded(object sender, EventArgs e)
        {
            if (Items == null) return;

            if (Items.Count > 0)
            {
                PlayFirstSlide();
            }
        }

        private void PlayFirstSlide()
        {
            if (Items.Count > 0)
            {
                var transitionElement = Content as TransitionElement;
                if (transitionElement != null)
                {
                    transitionElement.Content = Items[0].MediaElement;
                    transitionElement.Transition = Items[0].Transition;
                    elementTimer.Interval = Items[0].Duration.TimeSpan;
                    HasLoaded = true;
                }
            }
            else
            {
                HasLoaded = false;
            }
        }


        void elementTimer_Tick(object sender, EventArgs e)
        {
            Next();
        }

        public static readonly DependencyProperty CurrentItemIndexProperty =
            DependencyProperty.Register("CurrentItemIndex", typeof(int), typeof(PlaylistControl),
            new PropertyMetadata(new PropertyChangedCallback(currentItemIndex_changed)));

        public int CurrentItemIndex
        {
            get { return (int)GetValue(CurrentItemIndexProperty); }
            set { SetValue(CurrentItemIndexProperty, value); }
        }

        public static RoutedEvent CurrentItemIndexChangedEvent =
            EventManager.RegisterRoutedEvent("CurrentItemIndexChanged", RoutingStrategy.Bubble,
            typeof(RoutedPropertyChangedEventHandler<int>), typeof(PlaylistControl));

        public event RoutedPropertyChangedEventHandler<int> CurrentItemChanged
        {
            add { AddHandler(CurrentItemIndexChangedEvent, value); }
            remove { RemoveHandler(CurrentItemIndexChangedEvent, value); }
        }

        protected virtual void OnCurrentItemIndexChanged(int oldValue, int newValue)
        {
            if (Items.Count > 0)
            {
                RoutedPropertyChangedEventArgs<int> args = new RoutedPropertyChangedEventArgs<int>(oldValue, newValue);
                args.RoutedEvent = CurrentItemIndexChangedEvent;
                RaiseEvent(args);
                var transitionElement = Content as TransitionElement;
                if (transitionElement != null)
                {
                    transitionElement.Transition = Items[newValue].Transition;
                    elementTimer.Interval = Items[newValue].Duration.TimeSpan;
                    transitionElement.Content = Items[newValue].MediaElement;
                }
            }
            else
            {
                var transitionElement = Content as TransitionElement;
                if (transitionElement != null)
                {
                    transitionElement.Content = null;
                    RoutedPropertyChangedEventArgs<int> args = new RoutedPropertyChangedEventArgs<int>(oldValue,
                                                                                                       newValue);
                    args.RoutedEvent = CurrentItemIndexChangedEvent;
                    RaiseEvent(args);
                }
            }
        }

        public void Play()
        {
            if ((!elementTimer.IsEnabled && Items.Count > 0))
            {
                if (HasLoaded)
                    elementTimer.Start();
                if (Items[CurrentItemIndex].MediaElement.GetType() == typeof(Movie))
                {
                    //MediaElement mediaElement = Items[CurrentItemIndex].MediaElement as MediaElement; // TODO: fix so that Movie plays when Play is called.
                    //if (mediaElement != null) mediaElement.Play();
                }
                else
                {
                    PlayFirstSlide();
                    elementTimer.Start();
                }
            }
        }

        public void Stop()
        {
            if (elementTimer.IsEnabled)
            {
                elementTimer.Stop();
                if(Items[CurrentItemIndex].MediaElement.GetType() == typeof(Movie))
                {
                    //Movie movie = Items[CurrentItemIndex].MediaElement as Movie;

                    //int count = VisualTreeHelper.GetChildrenCount(movie);

                    //for (int i = 0; i < count; i++)
                    //{
                    //    UIElement child = (UIElement)VisualTreeHelper.GetChild(TransitionBox, i);
                    //    if (child.GetType() == typeof(Grid) && ((Grid)child).Name == "PART_MovieElement") // TODO: fix so that Movie is Paused when stop is called.
                    //    {
                    //        MediaElement mediaElement = ((Grid)child).Children[0] as MediaElement;
                    //        if(mediaElement != null) mediaElement.Pause();
                    //    }
                    //}         

                    //MediaElement mediaElement = VisualTreeHelper.
                    //if (mediaElement != null) mediaElement.Pause();
                }
            }
        }

        public void First()
        {
            if ((Items.Count > 1) && (CurrentItemIndex > 0))
            {
                CurrentItemIndex = 0;
            }
        }

        public void Previous()
        {
            if (CurrentItemIndex > 0)
            {
                CurrentItemIndex--;
            }
            else
            {
                CurrentItemIndex = Items.Count - 1;
            }
        }

        public void Next()
        {
            if ((CurrentItemIndex >= 0) && CurrentItemIndex < (Items.Count - 1))
            {
                CurrentItemIndex++;
            }
            else
            {
                CurrentItemIndex = 0;
                if (!HasLoaded)
                    PlayFirstSlide();
            }
        }

        public void Last()
        {
            if ((Items.Count > 1) && (CurrentItemIndex < (Items.Count - 1)))
            {
                CurrentItemIndex = (Items.Count - 1);
            }
        }

        private static void currentItemIndex_changed(DependencyObject element, DependencyPropertyChangedEventArgs e)
        {
            PlaylistControl playlistControl = (PlaylistControl)element;
            playlistControl.OnCurrentItemIndexChanged((int)e.OldValue, (int)e.NewValue);
        }

        public virtual void Add(PlaylistElement playlistElement)
        {
            if (playlistElement != null)
            {
                Items.Add(playlistElement);
                if (Items.Count == 1)
                    Next();
            }
        }

        public virtual void RemoveAt(int index)
        {
            Items.RemoveAt(index);
            if (Items.Count >= 1)
                Next();
            else
            {
                HasLoaded = false;
                Previous();
            }
        }

        public void AddFilesToPlaylist(string[] fileNames)
        {
            foreach (var name in fileNames)
            {
                if (File.Exists(name))
                {
                    string extention = Path.GetExtension(name);
                    List<string> pictureExtensions = new List<string>(Picture.Extensions);
                    List<string> movieExtensions = new List<string>(Movie.Extensions);

                    PlaylistElement playlistElement = new PlaylistElement();
                    if (pictureExtensions.Contains(extention))
                    {
                        playlistElement.MediaElement = new Picture(name, Stretch.Fill);
                        playlistElement.Duration = new Duration(new TimeSpan(0, 0, 5));
                        playlistElement.Transition = new Transitionals.Transitions.FadeTransition();
                    }
                    else if (movieExtensions.Contains(extention))
                    {
                        playlistElement.MediaElement = new Movie(name, Stretch.Fill);
                        playlistElement.Duration = new Duration(new TimeSpan(0, 0, 5));
                        playlistElement.Transition = new Transitionals.Transitions.FadeTransition();
                    }
                    else
                    {
                        break;
                    }

                    Add(playlistElement);
                }
            }
        }

        private void resetEdgeCommands()
        {
            m_canFirstChanged();
            m_canLastChanged();
            m_canNextChanged();
            m_canPreviousChanged();
            m_canPlayChanged();
            m_canStopChanged();
        }

        private void resetCommands()
        {
            resetEdgeCommands();

            int parentItemsCount = Items.Count;

            if (parentItemsCount != m_commandItems.Count)
            {
                if (parentItemsCount > m_commandItems.Count)
                {
                    for (int i = m_commandItems.Count; i < parentItemsCount; i++)
                    {
                        m_commandItems.Add(new PlaylistCommandItem(this, i));
                    }
                }
                else
                {
                    Debug.Assert(parentItemsCount < m_commandItems.Count);
                    int delta = m_commandItems.Count - parentItemsCount;
                    for (int i = 0; i < delta; i++)
                    {
                        m_commandItems.RemoveAt(m_commandItems.Count - 1);
                    }
                }
            }

            Debug.Assert(Items.Count == m_commandItems.Count);

            for (int i = 0; i < parentItemsCount; i++)
            {
                m_commandItems[i].Content = Items[i];
            }

#if DEBUG
            for (int i = 0; i < m_commandItems.Count; i++)
            {
                Debug.Assert(m_commandItems[i].Index == i);
            }
#endif
        }

        private void resetProperties()
        {
            if (CurrentItemIndex >= Items.Count)
            {
                CurrentItemIndex = (Items.Count - 1);
            }
            else if (CurrentItemIndex == -1 && Items.Count > 0)
            {
                CurrentItemIndex = 0;
            }

            //resetCommands();
        }

        private bool canPlay()
        {
            // return (!elementTimer.IsEnabled && Items.Count > 0);
            return true;
        }

        private bool canStop()
        {
            return true;
            //return elementTimer.IsEnabled;
        }

        private bool canFirst()
        {
            return true;
            //return (Items.Count > 1) && (CurrentItemIndex > 0);
        }

        private bool canNext()
        {
            return true;
            // return (CurrentItemIndex >= 0) && CurrentItemIndex < (Items.Count - 1);
        }

        private bool canPrevious()
        {
            return true;
            //return CurrentItemIndex > 0;
        }

        private bool canLast()
        {
            return true;
            //return (Items.Count > 1) && (CurrentItemIndex < (Items.Count - 1));
        }

        private readonly ICommand _firstCommand, _previousCommand, _nextCommand, _lastCommand, _playCommand, _stopCommand;
        private readonly Action m_canFirstChanged, m_canPreviousChanged, m_canNextChanged, m_canLastChanged, m_canPlayChanged, m_canStopChanged;

        private readonly ObservableCollection<PlaylistCommandItem> m_commandItems = new ObservableCollection<PlaylistCommandItem>();

        #region IWeakEventListener Members

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(DispatcherTimerTickEventManager))
            {
                elementTimer_Tick(sender, e);
                return true;
            }
            if (managerType == typeof(LoadedEventManager))
            {
                PlaylistControl_Loaded(sender, e);
                return true;
            }
            return false;
        }

        #endregion


        #region IDisposable Members

        public virtual void Dispose()
        {
            LoadedEventManager.RemoveListener(this, this);
            DispatcherTimerTickEventManager.RemoveListener(elementTimer, this);
            Items.Clear();
        }

        #endregion
    }

    public class PlaylistElement : DependencyObject
    {
        public object MediaElement
        {
            get { return GetValue(MediaElementProperty); }
            set { SetValue(MediaElementProperty, value); }
        }

        public static readonly DependencyProperty MediaElementProperty =
            DependencyProperty.Register("MediaElement",
                typeof(object),
                typeof(PlaylistElement),
                new UIPropertyMetadata(false));

        public Transition Transition
        {
            get { return (Transition)GetValue(TransitionProperty); }
            set { SetValue(TransitionProperty, value); }
        }

        public static readonly DependencyProperty TransitionProperty =
            DependencyProperty.Register("Transition",
                typeof(Transition),
                typeof(PlaylistElement));

        public Duration Duration
        {
            get { return (Duration)GetValue(DurationProperty); }
            set { SetValue(DurationProperty, value); }
        }

        public static readonly DependencyProperty DurationProperty =
            DependencyProperty.Register("Duration",
                typeof(Duration),
                typeof(PlaylistElement));

    }
}