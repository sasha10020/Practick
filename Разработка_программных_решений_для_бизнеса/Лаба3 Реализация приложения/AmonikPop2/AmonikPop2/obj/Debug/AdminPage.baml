   M S B A M L   `   `   `  ����E  AAmonikPop2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:AmonikPop2
AmonikPop2  5          AmonikPop2.AdminPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:AmonikPop2     5      -   5          N� Title$  	AdminPage��5	      .��5      �  � RowDefinitions 5   
   �� 5      $	��13* �6    � ColumnDefinitions 5   
   �� 5      .+�5   
    � -   5        $��
AdminFrame��5      $	��500��6"   $	��900��6/   �� 5   
   $��Office:��6   $
��Left=�6"   $��28��6=   $	��Top=�6I   $��83��6a   $��
165,45,0,0q�6l   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	AdminGrid��5         AutoGenerateColumns .     
IsReadOnly . $��0,0,0,62q�6s   $
��Left=�6�   $	��760��6�   $	��351��6�   $��Verdana)�6�   $��Bottom=�6�    � 	Resources 5        AmonikPop2.ColorConverter   ColorConverter��%   &	          5      6'   5         RowStyle 5      �� 5       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�5      �� 	 �� Property	 � ��
 �� Value
 63   �� *
User_Color+ �� 	Converter# [  5         Columns 5       0  *System.Windows.Controls.DataGridTextColumn  5!      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6Q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *	FirstName+6]     5"      $ 	Last Name��6%   $ * 6U    68   �� *
LastName+6a     5#      $	 Age��6%   $ * 6O    62   ��  �� Path$	 Age�6[     5$      $ 	User Role��6%   $ * 6V    68   �� *	Role_user+6b     5%      -   5        EmailColumn��$ Email Adress��5%   :   $ * 6j    6P   �� *Email+6v     5&      $ Office��6%   $ * 6O    65   �� *Title+6[     5'      $ Active��6%      
Visibility$ Hidden=�65    6I   �� $ 
User_Color�5)      �� 5+   
   -   5        $��Change Role��5+      $
��Left=�6'   $��24��6B   $��
18,452,0,0q�6N   $	��Top=�6b   $��93��6z   6�   �� 5,   
   -   5         ��Name$ ButtonColor��5,      $��Enable/Disable Login��6&   $
��Left=�6E   $��26��6`   $��145,454,0,0q�6l   $	��Top=�6�   $	��121��6�   6�   �� 5-   
   -   5        $ 
Add_button��5-      $��Add user��6%   $
��Left=�68   $��22��6S   $	��Top=�6_   $	��108��6w   $��	16,50,0,0q�6�   6�   �� 5.   
   -   5         ��Name$ OfficeComboBox��5.      $
��Left=�6+   $��
277,50,0,0q�6F   $	��Top=�6Z   $	��120��6r    �� SelectedIndex$ 0��6�   51      52      