   M S B A M L   `   `   `  ���� A  =Vistas, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:InterfazWPFInterfazWPF  0    *InterfazWPF.ContenedorOpcionesElementoMenu   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:InterfazWPF     -     >�Name$  UserControl��$��270.667��$	��393�� � 	Resources    OnMouseEnter1 �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  OnMouseLeave1��%�   &	        &	 a     �� .��U� $ (UIElement.Opacity)�$ img_arriba_Resplandor��.\�  $ 0:0:0.3��$ 1Q��� .��U� $ (UIElement.Opacity)�$ img_arriba_Resplandor��.\�  $ 0��$ 1Q�  $ 0:0:0.3��$ 0Q� � Triggers :�  :� RoutedEvent$ Mouse.MouseEnter�� :� 
SourceName$ 
img_arriba��.[��� #��[  :� $ Mouse.MouseLeave��$ 
img_arriba��.[��� -   	 ��Name$#	 OnMouseLeave1_BeginStoryboard��#��[ .��� -   
 �Name$
 
LayoutRoot��.+��� 
���   �
���   � �� RadiusY$
 26.5�� �� RadiusX$
 26.5�� J� Opacity$	 0.5Q�$��8,8,4,1.667q�$��0��F� "���Ѐw��J�юS�^���@�
&��	
���   �$��18.666��$��0,0,149,-16.499q� �� Stretch$
 Fill=�
���   �$��Bottom=�$��0��$ 0.495Q�$��Right=�$��89�� J� RenderTransformOrigin$ 0.5,0.5&�z�V� .~��� �� ��  �� Angle$	 0.5Q�T� �� $
��Auto=�$��19,56.006,23,8q�.��� -    �Name$ pnl_opciones���� ���	#5E000000$��25��$��28,23.005,60,0q�$	 6.5��$	 6.5��
���   �$��0��$	��Top=��� -    ��Name$ txt_ruta��$��25��$��31.5,24.505,60,0q�$
��Wrap=�$��Nomina\Catalogos��$	��Top=�
�������$��13.333(��� -    ��Name$ img_arriba_Resplandor��$��Right=�$
��33.5��$��0,18.506,20.5,0q�$	��Top=�$��38��$ 0Q� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 10Q�   Color$ White��   	Direction$ 0Q�   ShadowDepth$ 0Q��� -   $ 
img_arriba��$��Right=�$
��33.5��$��0,18.506,20.5,0q�$	��Top=�$��38��