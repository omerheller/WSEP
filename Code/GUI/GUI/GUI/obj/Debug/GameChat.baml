   M S B A M L   `   `   `  ����>  :GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:GUIGUI  5          GUI.GameChat   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      #localclr-namespace:GUI     5        N� 
Background
  �OO/� N� Title$ GameChat��5
      .��5      �  � RowDefinitions 5   
   �� 5      $��8* �6   �� 5      $	��87* �6   .+�5   
   �� $
��Chat��6   $��	ExtraBold"�6   $��Center=�66   
�������6S   �� 5   
   -   5        $��messages��5       �� 
IsReadOnly . " �� VerticalScrollBarVisibility$ Visible=�65   $
��Left=�6\   $	��222��6w   $��0,5,-1,0q�6�   $��1��6�    �� TextWrapping$
 Wrap=�6�    �� AcceptsReturn . $�� ��6�   $	��Top=�6�   $	��201��6�   �� 5   
   -   5        $��message��5      $
��Left=�6!   $��23��6<   $��	1,237,0,0q�6H   $��1��6[   $
 Wrap=�6h   $�� ��6|   $	��Top=�6�   $	��157��6�   �� 5   
   -   5        $��SendMessageToChat��5   B    �� 	IsDefault . $
��Send��6[   $
��Left=�6j   $��162,239,0,0q�6�   $��1��6�   $	��Top=�6�   $��35��6�   5      5      