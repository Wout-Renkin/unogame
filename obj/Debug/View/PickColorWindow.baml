   M S B A M L   `   `   `  ����C  ?UnoGame2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:UnoGame2.ViewUnoGame2.View  5   	   #    UnoGame2.View.PickColorWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:UnoGame2.View     5   	     � WindowStyle$
  None=�5   	    � Title$ PickColorWindow��5
   	   $	��400��6!   $	��400��6.    � DataContext 5	   	   ��    mainViewModelLocator �� Source# [   �� Path$ PickColorWindowViewModel�.��5      �  � ColumnDefinitions 5   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      .+�5   
   �� $��0��6   $��0��6!   $
��Auto��6.   
���  ��
���  ��$	��red��6�   ��6_   �� *PickColorCommand+6�   �� 5   
   $��1��6   $��0��6!   $
��Auto��6.   
����  �
����  �$
��blue��6�   ��6a   �� *PickColorCommand+6�   �� 5   
   $��0��6   $��1��6!   $
��Auto��6.   
��� � �
��� � �$��green��6�   ��6c   �� *PickColorCommand+6�   �� 5   
   $��1��6   $��1��6!   $
��Auto��6.   
��� ���
��� ���$��yellow��6�   ��6e   �� *PickColorCommand+6�   5      5      