using System;
using System.Collections.Generic;

namespace Inspire
{
    public class SlideFile : Slide
    {
        public SlideFile(){}

        public SlideFile(Slide slide)
        {
            GUID = slide.GUID;
            Name = slide.Name;
            Background = slide.Background;
            Description = slide.Description;
            HResolution = slide.HResolution;
            VResolution = slide.VResolution;
            DefaultDuration = slide.DefaultDuration;
            ThumbNail = slide.ThumbNail;
            Buttons = slide.Buttons;
            LastModifiedDate = slide.LastModifiedDate;
            ModifiedBy = slide.ModifiedBy;
            Tags = slide.Tags;
            Rules = slide.Rules;
        }

        public Byte[] File { get; set; }

    }
}
