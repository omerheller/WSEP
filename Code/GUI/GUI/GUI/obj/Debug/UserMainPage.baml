   M S B A M L   `   `   `  ����>  :GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:GUIGUI  5          GUI.UserMainPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      #localclr-namespace:GUI     5        N� Title$  UserMainPage��5	      .��5      �  � 	Resources 5   
      GameCenterButton �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers P� Property P� Value	 �� 
TargetName  EditProfileButton  LogoutButton��%�  &	        &	 �    &	 )    �� 5      " ��6-   .�5      ��  � �� 5      �� 5      " ��6*   .R�5      � .+�5   "   �� $��btnImg��6(   $-��'./Images/Buttons/Regular/gamecenter.png��66   $
��Fill=�6g   5       5      P� 5   "    �@J�	IsFocused . 6?   P� 5   "    �@��IsDefaulted . 6A   P� 5   "    �@J�IsMouseOver . . �5   &   �� $	 btnImg��6-    � ��$* $./Images/Buttons/Over/gamecenter.png��5   -   5   #   P� 5   "    � �� . . �5   &   �� $	 btnImg��6-    � ��$- './Images/Buttons/Pressed/gamecenter.png��5   -   5   #   P� 5   "    � {� .  6?   5!      5#      5$      �� 5%      " ��6.   .�5&      ��  � �� 5'      �� 5(      " ��6*   .R�5)      � .+�5*   "   �� $��btnImg��6(   $.��(./Images/Buttons/Regular/editprofile.png��66   $
��Fill=�6h   5+       5,      P� 5-   "    �@J�	IsFocused . 6?   P� 5.   "    �@��IsDefaulted . 6A   P� 5/   "    �@J�IsMouseOver . . �50   &   �� $	 btnImg��6-    � ��$+ %./Images/Buttons/Over/editprofile.png��51   -   52   #   P� 53   "    � �� . . �54   &   �� $	 btnImg��6-    � ��$. (./Images/Buttons/Pressed/editprofile.png��55   -   56   #   P� 57   "    � {� .  6?   59      5;      5<      �� 5=      " ��6)   .�5>      ��  � �� 5?      �� 5@      " ��6*   .R�5A      � .+�5B   "   �� $��btnImg��6(   $)��#./Images/Buttons/Regular/logout.png��66   $
��Fill=�6c   5C       5D      P� 5E   "    �@J�	IsFocused . 6?   P� 5F   "    �@��IsDefaulted . 6A   P� 5G   "    �@J�IsMouseOver . . �5H   &   �� $	 btnImg��6-    � ��$&  ./Images/Buttons/Over/logout.png��5I   -   5J   #   P� 5K   "    � �� . . �5L   &   �� $	 btnImg��6-    � ��$) #./Images/Buttons/Pressed/logout.png��5M   -   5N   #   P� 5O   "    � {� .  6?   5Q      5S      5T      5U      ��5V   
   �� 5W      
 �� ImageSource$
 ./Images/background2.jpg��6    j� Stretch$ UniformToFill=�6@   .+�5Z   
   �� $��Center=�6   $	��Top=�6-   $	��100q�6E   
�������$��Welcome To BGU Poker��5[      $��40(�6+   �� 5\   
   -   5        $��Button��5\   *   $
��Left=�6;   $	��199��6V   $��49��6b   $��306,186,0,0q�6n   $	��Top=�6�   #���   6�   �� 5]   
   -   5        $��EditProfile��5]   +   $
��Left=�6A   $	��199��6\   $��49��6h   $��306,246,0,0q�6t   $	��Top=�6�   #���  6�   �� 5^   
   -   5        $��Logout��5^   &   $
��Left=�67   $	��199��6R   $��49��6^   $��306,306,0,0q�6j   $	��Top=�6   #���  6�   �� 5_   
   -   5        $��user_avatar��5_      $
��Left=�6#   $	��128��6>   $��
92,205,0,0q�6K   $	��Top=�6_   $	��142��6w   5`      5a      