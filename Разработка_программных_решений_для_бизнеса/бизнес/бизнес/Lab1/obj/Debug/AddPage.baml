   M S B A M L   `   `   `  ����?  ;Lab1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Lab1Lab1  5          Lab1.AddPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $localclr-namespace:Lab1     5        N� Title$  AddPage��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��Название��6   �� 5   
   $%��Количество звезд��6   $��1��6,   �� 5   
   $��Страна��6   $��2��6"   �� 5   
    �� 	MaxLength$	 100��6   $��1��6>   ��6"   �� *
Name_hotel+6>   �� 5   
   $��1��6   $��1��6"   $
��Left=�6O   $	��175��6j   ��6/   �� *Count_of_stars+6j   �� 5   
   -   5         ��Name$ ComboCountres��5       �� DisplayMemberPath$ Name_country��6K   $��2��6l   $��1��6y    �� SelectedItem 6*   �� *	Country+6y   �� 5   
   -   5        $��BtnSave��5   F   $��Сохранить��6   $��2��6%   $��3��69   6U   5      5      