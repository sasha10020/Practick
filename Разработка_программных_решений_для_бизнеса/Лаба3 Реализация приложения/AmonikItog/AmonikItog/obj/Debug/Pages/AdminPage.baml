   M S B A M L   `   `   `  ����E  AAmonikItog, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:AmonikItog
AmonikItog  5           AmonikItog.Pages.AdminPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:AmonikItog     5      -   5          N� Title$  	AdminPage��5	      .��5      �  � RowDefinitions 5   
   �� 5      $	��30* �6   �� 5      $
��189* �6   �� 5      $	��31* �6    � ColumnDefinitions 5   
   �� 5      $	��82* �6   �� 5      $	��77* �6   �� 5      $
��159* �6   �� 5      $	��80* �6   �� 5      $
��164* �6   �� 5      $	��79* �6   �� 5      $
��191* �6   �� 5      $	��68* �6   .+�5   
   �� $��Office:��6   $��Center=�6"   $��28��6?   $	��Top=�6K   $��54��6c   $��0,22,0,0q�6n   $��3��6�   $��	Tw Cen MT)�6�   $��18(�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	AdminGrid��5         AutoGenerateColumns .     
IsReadOnly . $��	Tw Cen MT)�6�   $��	0,13,2,13q�6�   $��6��6�   $��1��6�   $��1��6�   $��18(�6�    � 	Resources 5         AmonikItog.ColorConverter   ColorConverter��%   &	          5!      6'   5"         RowStyle 5#      �� 5$       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�5%      �� 	 �� Property	 � ��
 �� Value
 63   �� *
User_Color+ �� 	Converter# [  5&         Columns 5(      0  *System.Windows.Controls.DataGridTextColumn  5)      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6Q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *	FirstName+6]     5*      $ 	Last Name��6%   $ * 6U    68   �� *
LastName+6a     5+      $	 Age��6%   $ * 6O    62   ��  �� Path$	 Age�6[     5,      $ 	User Role��6%   $ * 6V    68   �� *	Role_user+6b     5-      -   5        EmailColumn��$ Email Adress��5-   :   $ * 6j    6P   �� *Email+6v     5.      $ Office��6%   $ * 6O    65   �� *Title+6[     5/      $ Active��6%      
Visibility$ Hidden=�65    6I   �� $ 
User_Color�51      �� 53   
   -   5        $��Change Role��53      $��Center=�6'   $��24��6D   $��0,15,0,0q�6P   $	��Top=�6b   $	��106��6z   $��2��6�   $��2��6�   ���	#FF3799E6$��	Tw Cen MT)�6�   $��18(�6�   �� 54   
   -   5         ��Name$ ButtonColor��54      $��Enable/Disable Login��6&   $��Center=�6E   $��26��6b   $��0,14,0,0q�6n   $	��Top=�6�   $	��171��6�   $��2��6�   $��6��6�   ���	#FF3799E6$��	Tw Cen MT)�6�   $��18(�6	  �� 55   
   -   5        $ 
Add_button��55      $��Add user��6%   $��Center=�68   $��22��6U   $	��Top=�6a   $	��138��6y   $��0,28,0,0q�6�   $��2��6�   ���	#FF3799E6$��	Tw Cen MT)�6�   $��18(�6�   �� 56   
   -   5         ��Name$ OfficeComboBox��56      $��Center=�6+   $��0,25,0,0q�6H   $	��Top=�6Z   $	��160��6r    �� SelectedIndex$ 0��6�   $��4��6�   $��22��6�   $��	Tw Cen MT)�6�   $��18(�6�   ��57      �� 58       �� EndPoint$	 0,1&�6&   .��59      �  � Color$ 	#FFF0F0F0��6#   � 5:      $ 	#FFDDEDF9��6#    � Offset$ 1Q�65   5;      5=      �� 5>   
   -   5        $ 
ExitButton��5>      $
��Exit��6%   $��Center=�64   $��24��6Q   $��0,26,0,0q�6]   $	��Top=�6o   $	��108��6�   $��6��6�   ���	#FF3799E6$��	Tw Cen MT)�6�   $��18(�6�   5B      5C      