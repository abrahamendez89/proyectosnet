   M S B A M L   `   `   `  ����A  =Vistas, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:InterfazWPFInterfazWPF  5      0    *InterfazWPF.ContenedorOpcionesElementoMenu   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      +localclr-namespace:InterfazWPF     5      -   5          >�Name$  UserControl��5	      $��270.667��6   $	��393��6(    � 	Resources 5
         OnMouseEnter1 �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  OnMouseLeave1��%�  &	        &	 �     �� 5      .��5      U� $ (UIElement.Opacity)�6#   $ img_arriba_Resplandor��6S   .\�5        $ 0:0:0.3��6   $ 1Q�6-   5      5      �� 5      .��5      U� $ (UIElement.Opacity)�6#   $ img_arriba_Resplandor��6S   .\�5        $ 0��6   $ 1Q�6'     5      $ 0:0:0.3��6   $ 0Q�6-   5      5      5       � Triggers 5      :� 5       :� RoutedEvent$ Mouse.MouseEnter��6    :� 
SourceName$ 
img_arriba��60   .[�5      �� #��[  6   5      :� 5      $ Mouse.MouseLeave��6   $ 
img_arriba��60   .[�5      �� -   5        	 ��Name$#	 OnMouseLeave1_BeginStoryboard��5      #��[ 6<   5      .��5       � -   5        
 �Name$
 
LayoutRoot��5       .+�5!      �� 
���   �
���   � �� RadiusY$
 26.5��6*    �� RadiusX$
 26.5��69    J� Opacity$	 0.5Q�6H   $��8,8,4,1.667q�6V   $��0��6k   F� 5"      "���Ѐw��J�юS�^���@�
&��	
���   �$��18.666��6U   $��0,0,149,-16.499q�6e    �� Stretch$
 Fill=�6~   
���   �$��Bottom=�6�   $��0��6�   $ 0.495Q�6�   $��Right=�6�   $��89��6�    J� RenderTransformOrigin$ 0.5,0.5&�6  z�5#      V� 5$      .~�5%      �� �� 5&      �� 5'       �� Angle$	 0.5Q�6   T� 5(      5)      5+      �� 5,      $
��Auto=�6   $��19,56.006,23,8q�65   .��5-      � -   5         �Name$ pnl_opciones��5-      5.      �� 5/      ���	#5E000000$��25��6   $��28,23.005,60,0q�6+   $	 6.5��6C   $	 6.5��6Q   
���   �$��0��6n   $	��Top=�6�   �� 50      -   5         ��Name$ txt_ruta��50      $��25��6    $��31.5,24.505,60,0q�6,   $
��Wrap=�6F   $��Nomina\Catalogos��6Z   $	��Top=�6r   
�������$��13.333(�6�   �� 51      -   5         ��Name$ img_arriba_Resplandor��51   
   $��Right=�6)   $
��33.5��6E   $��0,18.506,20.5,0q�6S   $	��Top=�6l   $��38��6�   $ 0Q�6�    J� Effect 52      3  -System.Windows.Media.Effects.DropShadowEffect  53         
BlurRadius$ 10Q�6      Color$ White��6'      	Direction$ 0Q�65      ShadowDepth$ 0Q�6C   55      �� 56      -   5        $ 
img_arriba��56   
   $��Right=�6   $
��33.5��6:   $��0,18.506,20.5,0q�6H   $	��Top=�6a   $��38��6y   6�   57      58      