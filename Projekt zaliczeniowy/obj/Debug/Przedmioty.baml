   M S B A M L   `   `   `  ����O  KProjekt zaliczeniowy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Projekt_zaliczeniowyProjekt_zaliczeniowy  5   	   %    Projekt_zaliczeniowy.Przedmioty   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:Projekt_zaliczeniowy     5   	     � Title$  
Przedmioty��5   	   $	��450��6   $	��800��6)   .��5	      ]� .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ myGrid��5
         AutoGenerateColumns .     ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6X      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ nazwa��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *nazwa+  5      $ 
nauczyciel��6%    69   �� *
nauczyciel+  5      $ klasa��6%    64   �� *klasa+4  .System.Windows.Controls.DataGridTemplateColumn  5         HeaderTemplate 5      �� 5      .R�5      �� $��Funkcje��6(   5         CellTemplate 5      �� 5      .R�5      �� 	 �� Orientation$	 
Horizontal=�6)   .+�5   "   �� 
 ��Name$
 	insertbtn��6)   -   5        $��Insert��5   <   6M   �� 5   "   $
 	deletebtn��6)   -   5        $��Delete��5   <   6M   �� 5   "   $
 	updatebtn��6)   -   5        $��Update��5   <   6M   5      5      5!      5'      5,      5-      