   M S B A M L   `   `   `  ����
  VistasQ    KInterfazWPF.AdministracionSistema.ControlesUsuario.TextboxSoloNumeroDecimal   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $��25��5   3     � 	Resources  5         OnMouseEnter1 �� TargetProperty �� 
TargetName8  2System.Windows.Media.Animation.EasingColorKeyFrame �� KeyTime �� Value  OnMouseLeave1��%B  &	        &	 �    �� 5      .��5	      �� $0 *(Panel.Background).(SolidColorBrush.Color)�6"   $ txt_Algo��6i   .g�5
        $ 0:0:0.2��6   $ White��6,   5      �� 5      $* $(Shape.Fill).(SolidColorBrush.Color)�6"   $ ellipse��6c   .g�5        $ 0:0:0.2��6   $ White��6,   5      �� 5      $* $(Shape.Fill).(SolidColorBrush.Color)�6"   $ ellipse1��6c   .g�5        $ 0:0:0.2��6   $ White��6,   5      5      �� 5      .��5      �� $* $(Shape.Fill).(SolidColorBrush.Color)�6"   $ ellipse��6c   .g�5        $ 0��6   $ White��6&     5      $ 0:0:0.3��6   $ 	#FFF0F0F0��6,   5      �� 5      $* $(Shape.Fill).(SolidColorBrush.Color)�6"   $ ellipse1��6c   .g�5        $ 0��6   $ White��6&     5      $ 0:0:0.3��6   $ 	#FFF0F0F0��6,   5      �� 5      $0 *(Panel.Background).(SolidColorBrush.Color)�6"   $ txt_Algo��6i   .g�5        $ 0��6   $ White��6&     5      $ 0:0:0.3��6   $ 	#FFF0F0F0��6,   5      5       5!       � Triggers 5"      :� 5#       :� RoutedEvent$ Mouse.MouseEnter��6   .[�5$      �� #��[  6   5%      :� 5&      $ Mouse.MouseLeave��6   .[�5'      �� -   5         ��Name$# OnMouseLeave1_BeginStoryboard��5'      #��[ 6<   5(      .��5*      � .+�5+   
   A� -   5         A�Name$ ellipse��5+      ���	#FFF0F0F0$
��Left=�64   
���   �$��14��6^   	 J� OpacityMask
	 �   �6i   A� 5,   
   -   5        $ ellipse1��5,      ���	#FFF0F0F0
���   �$��Right=�6D   $��14��6`   
	 �   �6k   �� 5-   
   -   5        
 ��Name$
 txt_Algo��5-      $	��7,0q�6$   
������� �� SelectionBrush �	#FF00D1FF$��0q�6�   
	 �   ����	#FFF0F0F0 �� TextAlignment$ Right=�6�   $��Center=�6�   6  F� 5.   
   ���P��j ��QUU�?	���	#FFF4F4F5$
��Left=�65   $��1��6P   $��7,0.333,0,0q�6[    �� Stretch$
 Fill=�6p   
���   �$	��Top=�6�   $��1��6�   F� 5/   
   ������j � �@�� 	���	#FFF4F4F5$��1��6:   $��6.062,0,5.602,0q�6E   $
 Fill=�6^   
���   �$	��Top=�6|   F� 50   
   ������j � �@�� 	���	#FFF4F4F5$��6.25,0,5.874,0q�6:   $
 Fill=�6R   
���   �$��1��6p   $��Bottom=�6{   52      53      