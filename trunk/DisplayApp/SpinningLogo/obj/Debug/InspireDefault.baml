   M S B A M L   `   `   `  ����G  CSpinningLogo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:SpinningLogoSpinningLogo  5      !    SpinningLogo.InspireDefault   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      ,localclr-namespace:SpinningLogo     5        � 	Resources  5         sbLoaded g� RepeatBehavior g� AutoReverse g� Duration g� 	BeginTime �� 
TargetName �� TargetProperty �� KeyTime �� Value	 �� Angle
 �� Axis O� KeyTime O� Value��%7	  &	        �� 5   
   $ Forever��6&    . $ 00:00:02.5000000D�6R   .��5      �� $ 00:00:00X�60   $ topModelVisual3D��6E   $V P(Visual3D.Transform).(Transform3DGroup.Children)[2].(RotateTransform3D.Rotation)�6n   .�5      �� $ 00:00:00.5000000��6+    5	      �� 5
      $	 46.567463442210148Q�6.   $:
 40.447213595499955,0.774596669241484,0.447213595499965�6I   5      �� 5      $ 00:00:01��6+    5      �� 5      $	 78.477102851225609Q�6.   $:
 40.250562807085731,0.93511312653103,0.2505628070857325�6I   5      �� 5      $ 00:00:01.5000000��6+    5      �� 5      $		 180Q�6.   $1
 +-6.12303176911192E-17,2.8327492261615E-16,15�6:   5      �� 5      $ 00:00:02��6+    5      �� 5      $	 148.600285190081Q�6.   $=
 7-0.678598344545847,-0.28108463771482,-0.6785983445458475�6G   5      �� 5      $ 00:00:02.5000000��6+    5      �� 5      $	 338.81717773037957Q�6.   $>
 8-0.704062592219638,-0.704062592219635,0.09269159872357155�6I   5       5!      U� 5"      $ 00:00:00X�6,   $ topModelVisual3D��6A   $S M(Visual3D.Transform).(Transform3DGroup.Children)[1].(ScaleTransform3D.ScaleX)�6j   .\�5#      �� $ 00:00:00.5000000��6'   $ 1Q�6B   �� 5$      $ 00:00:01��6'   $ 2Q�6:   �� 5%      $ 00:00:01.5000000��6'   $	 1.5Q�6B   �� 5&      $ 00:00:02��6'   $	 1.5Q�6:   �� 5'      $ 00:00:02.5000000��6'   $ 1Q�6B   5(      U� 5)      $ 00:00:00X�6,   $ topModelVisual3D��6A   $S M(Visual3D.Transform).(Transform3DGroup.Children)[1].(ScaleTransform3D.ScaleY)�6j   .\�5*      �� $ 00:00:00.5000000��6'   $ 1Q�6B   �� 5+      $ 00:00:01��6'   $ 2Q�6:   �� 5,      $ 00:00:01.5000000��6'   $	 1.5Q�6B   �� 5-      $ 00:00:02��6'   $	 1.5Q�6:   �� 5.      $ 00:00:02.5000000��6'   $ 1Q�6B   5/      U� 50      $ 00:00:00X�6,   $ topModelVisual3D��6A   $S M(Visual3D.Transform).(Transform3DGroup.Children)[1].(ScaleTransform3D.ScaleZ)�6j   .\�51      �� $ 00:00:00.5000000��6'   $ 1Q�6B   �� 52      $ 00:00:01��6'   $ 2Q�6:   �� 53      $ 00:00:01.5000000��6'   $	 1.5Q�6B   �� 54      $ 00:00:02��6'   $	 1.5Q�6:   �� 55      $ 00:00:02.5000000��6'   $ 1Q�6B   56      57      58      .��59      � -   5         �Name$ 
LayoutRoot��59      .+�5:   
   '� -   5         '�Name$ 
myViewport��5:        5;       
 plane1 k� Normals k� 	Positions k� TextureCoordinates k� TriangleIndices 
 plane2 
 plane3 
 plane4 
 plane5 
 plane6��%H  &	       &	 �     &	     &	 �    &	     &	 �    k� 5<       �   5 �   �^�� �  � �^�� �  � �^���^�� �    �     6�   k� 5=       �   5 �   �^�� �  �  �  �  � �^�� �  �    �     6�   k� 5>       �   5 �   �^���^�� � �^�� � �^���^���^�� �    �     6�   k� 5?       �   5 �    �  �  � �^�� � �^�� �  �  �    �     6�   k� 5@       �   5 �   �^�� � �^���^���^���^���^�� �  �    �     6�   k� 5A       �   5 �   �^�� �  �  �  � �^���^���^�� �    �     6�   5B       '� Camera 5C      =� 5D      -   5        
Camera�� =� FieldOfView$ 45Q�5D   4    � FarPlaneDistance$ 20Q�6E    � LookDirection$ 5,-2,-35�6[    � NearPlaneDistance$	 0.1Q�6s    � Position$ -5,2,31�6�    � UpDirection$ 0,1,05�6�   .x�5F      g�  g� Content 5G      h� 5H      -   5        	Scene��  SceneTR8 j� 	Transform# �  5H   2   .��5I      ��  �� Color$ #333333��6'   t� 5J      $ #C0C0C0��6+    t� 	Direction$ 5,0,-15�6;   t� 5K      $ #C0C0C0��6+   $ 1,0,-2.22045e-0165�6;   t� 5L      $ #C0C0C0��6+   $ -1,0,-2.22045e-0165�6;   t� 5M      $ #C0C0C0��6+   $ -2.44089e-016,0,15�6;   5N      5P      g� 5Q      -   5        topModelVisual3D�� g� 	Transform 5R      Y� 5S      .�5T      S�  S� OffsetX$ 0Q�6/     S� OffsetY$  0Q�6;   ! S� OffsetZ$! 0Q�6G   �� 5U      " �� ScaleX$" 1Q�6+   # �� ScaleY$# 1Q�66   $ �� ScaleZ$$ 1Q�6A   �� 5V      % �� Rotation% 5W      �� 5X   "   $	 1Q�66   $
 0,1,05�6@   5Z      S� 5[      $ 0Q�6/   $  0Q�6;   $! 0Q�6G   S� 5\      $ 0Q�6/   $  0Q�6;   $! 0Q�6G   5]      .2�5_      g�  5`      t� 5a      $ 	#FFFFFFFF��6+   $= 70.717509570032485,-0.687462205666443,-0.1121415743247225�6=   5c      5  /System.Windows.Media.Media3D.Viewport2DVisual3D  5e      &   Geometry#& [ 6%   '   Material' 5f      u� 5g      (   IsVisualHostMaterial( . ) u� Brush
) ��d�6Y   *   Visual.* 5i      �� -   5        + ��Name$
+ img1��5i      $��Images/NoImage.jpg��6*   $
��None=�6F   5j        5l      #& [ 6%   ' 5m      u� 5n      ( . 
) ��d�6Y   .* 5p      �� -   5        $
+ img2��5p      $��Images/NoImage.jpg��6,   $
��None=�6H   5q        5s      #& [ 6%   ' 5t      u� 5u      ( . 
) ��d�6Y   .* 5w      �� -   5        $
+ img3��5w      $��Images/NoImage.jpg��6+   $
��None=�6G   5x        5z      #& [ 6%   ' 5{      u� 5|      ( . 
) ��d�6Y   .* 5~      �� -	   5        $
+ img4��5~      $��Images/NoImage.jpg��6+   $
��None=�6G   5        5�      #& [ 6%   ' 5�      u� 5�      ( . 
) ��d�6Y   .* 5�      �� -
   5        $
+ img5��5�      $��Images/NoImage.jpg��6+   $
��None=�6G   5�        5�      #& [ 6%   ' 5�      u� 5�      ( . 
) ��d�6Y   .* 5�      �� -   5        $
+ img6��5�      $��Images/NoImage.jpg��6+   $
��None=�6G   5�      5�      5�      5�      5�      