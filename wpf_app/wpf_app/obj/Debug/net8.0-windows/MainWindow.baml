   M S B A M L   `   `   `  ����B  >wpf_app, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:wpf_appwpf_app  5   	       wpf_app.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:wpf_app     5   	     � Title$  
MainWindow��5   	   $	��400��6   $	��600��6)    � WindowStyle$
 None=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	    � AllowsTransparency$
 True��5   	    � 	Resources 5         PrimaryColor �� Color  SecondaryColor  PrimaryLightColor  SecondaryDarkColor  ButtonMouseOverColor  TextMouseOverColor  ButtonPressedColor  PrimaryButtonStyle �� 
TargetType �� Property �� Value	 �� 
TargetType
 ��Name J� SnapsToDevicePixels �� Padding ��Name �� Triggers P� Property P� Value �� 
TargetName��%  &	        &	 !     &	 B     &	 c     &	 �     &	 �     &	 �     &	 �     �� 5   
   $ #D9D2C5��6/   �� 5   
   $ #4D6C73��61   �� 5   
   $ #F2EBDC��64   �� 5   
   $ #012E40��65   �� 5   
   $ #4D6C73��67   �� 5   
   $ #D9D2C5��65   �� 5   
   $ #012E40��65   �� 5   
   " ��6+   .�5      ��  � ��# �   6+   �� 5       � ��# �  6+   �� 5       � ��$ 2.7,2.7,2.7,2.7q�60   �� 5       � ��# �  6,   �� 5       � ��$ 50��6'   �� 5       � ��$	 200��6&   �� 5       � ��$ Center=�6;   �� 5        � ��$ Center=�69   �� 5!       � ��$ Cascadia Code)�6+   �� 5"       � ��$ 18(�6)   �� 5#       � �� 5$      �� 5%      "	 ��6&   .R�5&      �� $
 	btnBorder��6!   #��z��5'   !   #��z��5(   !   #��z��5)   !   #��z��5*   !   #��z��5+   !   $
 True��5,   !   # z��5-   !   ._�5.      �� $ ContentPresenter��6/   $|�False��6I   #��z��5/   /   #��z��50   /   #��z��51   /   # z 52   /   $
��True��53   /   54       55      P� 56       �@J�IsMouseOver$
 True��6=   . �57   "   �� $ 	btnBorder��6)   # �  6V    � ���� 58   "   # �  6?    � ���� 59   "    � ��$ 0q�6D   5:      P� 5;       � ��$
 True��6;   . �5<   "   �� $ 	btnBorder��6)   # �  6V    � ���� 5=   "   # �  6?    � ���� 5>   "    � ��$ 2.7,2.7,2.7,2.7q�6D   �� 5?   "   # �  6@    � ��5@      5B      5D      5E      5F      .��5H      � ���#D9D2C5.+�5K   
   �� -   5        $��X��5K      #���  67   $��Right=�6d   $	��Top=�6�   $��40��6�   $��30��6�   $��	0,10,10,0q�6�   �� 5N   
   $ ��WYPOŻYCZALNIA SAMOCHODÓW��6   ���	#FF4D6C73$��	0,0,0,250q�6K   $��Cascadia Code)�6^   $��18(�6y   $��Center=�6�   $��Center=�6�   �� 5Q   
   $��Center=�6   $	��Top=�62    �� Orientation$ Vertical=�6J   $��	0,150,0,0q�6a   .+�5R      �� -   5        $��	SAMOCHODY��5R      #���  6)   $��	0,0,-1,10q�6t   �� 5S      -   5        $��KLIENCI��5S      #���  6'   $��0,0,0,10q�6p   �� 5T      -   5        $��WYPOŻYCZENIA��5T      #���  6,   6Y   5U      5V      5X      