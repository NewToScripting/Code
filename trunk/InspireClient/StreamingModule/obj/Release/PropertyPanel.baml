   M S B A M L   `   `   `  ���� B  >Inspire, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:Inspire;assembly=InspireInspire   StreamingModule#   StreamingModule.PropertyPanel   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     :Inspire&clr-namespace:Inspire;assembly=Inspire     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006       � 	Resources  ��%     � Triggers .���� -    ��Name$
 grid��$��	0,0,-15,0q�   SunkenBackground#��[  $��Right=� J� RenderTransformOrigin$ 0.5,0.5&�$	��260��z�V� .~���  �� ScaleX$ 1Q� �� ScaleY$ 1Q���  �� AngleX$ 0Q� �� AngleY$ 0Q���  �� Angle$ 0Q�T� 	 T� X$	 0Q�
 T� Y$
 0Q� J� BitmapEffect ��  �� 
BevelWidth$ 3Q� �� EdgeProfile$ BulgedUp=� �� Relief$ .1Q�._��� $��5q�$��Stretch=�#��[  .+�   Inspire.PropertyBase  -   $��propBase��$��5,5,10,5q�9�  9� 
IsExpanded . $��Video Properties��$��5,0,10,5q�  WindowBackgroundBrush#��[ .��� $	��Top=�$��71��.+��� -    ��Name$ 
txtStretch��$��	10,8,0,31q�
�������$��Right=�$
��Left=�$��53��$��Strech:���� -    ��Name$ 	tbStretch��$��72,11,48,35q� �� Text ��  �� Path$ Content.Content.Stretch� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�.@��� $��Uniform���� $
��Fill���� $
��None���� $��UniformToFill���� -   $��slider1��$��72,0,5,2q� � Minimum$ 0Q� � Maximum$ 1Q�$��25��$��Bottom=� � Value �� $ Content.Content.Volume�$ TwoWay=�$ PropertyChanged=��� -   $��label1��
�������$
��Left=�$��Right=�$��10,0,0,0q�$��53��$��32��$��Bottom=�.��	Volume: