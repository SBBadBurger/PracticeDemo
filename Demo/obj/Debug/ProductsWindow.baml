   M S B A M L   `   `   `  ����?  ;Demo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:DemoDemo  5   	       Demo.ProductsWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Demo     5   	     � Title$  Главное окно��5   	   $	��550��6   $
��1000��6+   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��50* �6   �� 5      $
��277* �6   �� 5      $	��73* �6   .+�5   
    � -   5          �Name$ 	MainFrame��5      $��1��6#     � NavigationUIVisibility$ Hidden=�63   $��2��6S   �� 5   
   ���	#FFFFCC99.+�5      �� -   5         ��Name$ ProductButton��5      $��Товары��6,   $	��0 5q�6=   6J   �� 5      -   5        $ OrdersButton��5      $��Заказы��6+   $	��0 5q�6<   $y�	Collapsed=�6d   5      �� 5   
   -   5         ��Name$ NameTextBlock��5      $��Bottom=�6+   $��0,0,0,40q�6F   $��Center=�6X   $
��Wrap=�6u   �� 5   
   -   5        $ 
ExitButton��5      $��
Выйти��6%   $��Bottom=�65   $��	0,413,0,0q�6i   5      5      