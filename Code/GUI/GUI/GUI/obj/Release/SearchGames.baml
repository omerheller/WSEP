   M S B A M L   `   `   `  ����   GUI    GUI.SearchGames   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008       N� Title$  SearchGames��.���  � RowDefinitions �� $
��127* ��� $
��442* �����  �� ImageSource$ ./Images/background2.jpg�� j� Stretch$ UniformToFill=�.+��� 
���   � J� OpacityMask
 �   � J� Opacity$ 50Q�
�������$��35(�$
��Bold"�$��Medium&�$
��Left=�$��
302,10,0,0q�$	��Top=�.���� 
���   �
 �   �$ 50Q�
�������$��35(�$
��Bold"�$��Medium&�$��Find Games:��$
��Left=�$	��Top=��� 
���   �
 �   �$ 50Q�
�������$��16(�$
��Bold"�$��Medium&�$��Player Name:��$
��Left=�$��	16,70,0,0q�$	��Top=��� 
���   �
 �   �$ 50Q�
�������$��16(�$
��Bold"�$��Medium&�$��Potsize:��$
��Left=�$��
16,107,0,0q�$	��Top=�$��2���� 
���   �
 �   �$ 50Q�
�������$��16(�$
��Bold"�$��Medium&�$��Small Blind:��$
��Left=�$��16,22.2,0,0q�$	��Top=�$��1���� 
���   �
 �   �$ 50Q�
�������$��16(�$
��Bold"�$��Medium&�$��Buy In:��$
��Left=�$��16,62.2,0,0q�$	��Top=�$��1���� 
���   �
 �   �$ 50Q�
�������$��16(�$
��Bold"�$��Medium&�$��Type Policy:��$
��Left=�$��15,103.2,0,0q�$	��Top=�$��1���� 
���   �
 �   �$ 50Q�
�������$��16(�$
��Bold"�$��Medium&�$��Chip Policy:��$
��Left=�$��15,149.2,0,0q�$	��Top=�$��1���� -   $��player_name��$
��Left=�$��26��$��
155,75,0,0q� �� TextWrapping$
 Wrap=�$�� ��$	��Top=�$	��124���� -    ��Name$ pot_size��$
��Left=�$��26��$��155,112,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��124��$��2���� -   $ small_blind��$
��Left=�$��26��$��155,27.2,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��124��$��1���� -   $ buy_in��$
��Left=�$��26��$��155,67.2,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��124��$��1���� -    ��Name$ Type_Policy��$
��Left=�$��26��$��155,110.2,0,0q�$	��Top=�$	��124��$��1��.@��� $��Limit��$
��Left=�$	��134���� $��No Limit��$
��Left=�$	��134���� $��	Pot Limit��$
��Left=�$	��134���� -   $ chip_policy��$
��Left=�$��26��$��155,154.2,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��124��$��1���� -   $��	Find_game��$��Search��$
��Left=�$��36��$��82,223.2,0,0q�$��1��$	��Top=�$	��143���� -   $��playBtn��$
��Play��$
��Left=�$��36��$��489,223.2,0,0q�$��1��$	��Top=�$	��112���� -	   $��spectateBtn��$��Spectate��$
��Left=�$��36��$��634,223.2,0,0q�$��1��$	��Top=�$	��112���� 
���   �
 �   �$ 50Q�
�������$��16(�$
��Bold"�$��Medium&�$��Allow Spectating:��$
��Left=�$��16,179.2,0,0q�$	��Top=�$��1���� -
   $��
Allow_Spec��$
��Left=�$��22��$��165,189.2,0,0q�$��1��$	��Top=�$��25��	 J� RenderTransformOrigin$	 0.624,-0.373&�&   System.Windows.Controls.DataGrid  -   
  Name$
 Display_game_results��$
��Left=�$��
469,86,0,0q�$	��Top=�$	��242��$��2��$	��315��   CanUserResizeColumns .     
IsReadOnly . �� -   $��goBack��$��Go Back��$
��Left=�$��16,361.667,0,0q�$��1��$	��Top=�$��75��