   M S B A M L   `   `   `  ����C  ?UnoGame2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:UnoGame2.ViewUnoGame2.View  5   	       UnoGame2.View.GameWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   'localclr-namespace:UnoGame2.View  5   	     � Title$  
GameWindow��5   	   $	��450��6   $	��800��6)    � DataContext 5	   	   ��    mainViewModelLocator �� Source# [   �� Path$ GameWindowViewModel���5      �� 5   
    �� ImageSource$ /Images/background2i.jpg��6    � 	Resources 5       	 hover �� 
TargetType �� Triggers P� Property	 P� Value
 �� Property �� Value �� ScaleX �� ScaleY  hoverButton��%
  &	       &	 �     �� 5   
   " ��6    5      P� 5       �@J�IsMouseOver	 . . �5      �� 
 �@J�RenderTransformOrigin$ 0.5, 0.5&�6B   �� 5      
 � z� 5      �� 5   "   $	 1.2Q�61   $	 1.2Q�6>   5      5      5      �� 5   
   " ��6$    5      P� 5        �@J�IsMouseOver	 . . �5!      �� 
 �@J�RenderTransformOrigin$ 0.5, 0.5&�6>   �� 5"      
 � z� 5#      �� 5$      $	 1.2Q�6-   $	 1.2Q�6:   5&      5'      5)      5*      .��5,      �  � RowDefinitions 5-   
   �� 5.      $��2* �6   �� 5/      $��5* �6   �� 50      $��3* �6   .+�52   
   �� $��0��6   $��Disabled=�6    $
��Auto=�6T   $��Center=�6�   ��6�   �� *Bot2+��53      �� 54      .R�55      ��  �� Orientation$ 
Horizontal=�6!   56      ��58      �� 59      .R�5:      �� $��0q�6   $e��_C:\\Users\\Wout\\Desktop\\WPF\\Oefeningen\\UnoGame2\\bin\\Debug\\Images\\UNOCards\\cardback.png��6'   $	��100��6�   5;      5<      5>      �� 5?   
   $��2��6   $��2��6    $��Disabled=�61   $
��Auto=�6e   $��Center=�6�   ��6�   �� *
PlayerHand+ �� SelectedItem 6�   �� *CurrentCard+��5@      �� 5A      .R�5B      �� $ 
Horizontal=�6!   5C      ��5E      �� 5F      .R�5G      �� $ 
Horizontal=�6!   $	��200��6:   .+�5H      �� #��[ 6    $	��200��6]   $
��Fill=�6j   ��6?   �� *
Card.Image+6j   5I      5J      5L      � 5M   
   $��1��6    � ColumnDefinitions 5N      �� 5O      $
��1.2* �6#   �� 5P      $
��2.5* �6#   �� 5Q      $��4* �6#   �� 5R      $
��2.5* �6#   �� 5S      $
��1.5* �6#   .+�5U      �� $��0��6   ��6'   �� *Bot1+��5V      �� 5W      .R�5X      A�  A� Columns$ 1��6&   5Y      ��5[      �� 5\      .R�5]      �� $��0q�6    $e��_C:\\Users\\Wout\\Desktop\\WPF\\Oefeningen\\UnoGame2\\bin\\Debug\\Images\\UNOCards\\cardback.png��6+   $	��100��6�    � LayoutTransform 5^      �� 5_   "    �� CenterX$ 25Q�62    �� CenterY$ 25Q�6?    �� Angle$ 90Q�6L   5a      5b      5d      � 5e      $��2��6    5f      �� 5g      $��2* �6'   �� 5h      $��2* �6'    5j      �� 5k      $
��8.5* �6$   �� 5l      $
��1.5* �6$   .+�5n      �� $��0��6   $��0��6&   $	��200��6c   ��66   �� *LastPlayedCard.Card.Image+6c   �� 5o      #��[ 6   $��0��6B   $��1��6O   $	��200��6_   $��133.7��6l   ��6{   �� *
DrawCard+��5q      �� 5r      .R�5s      �� $e��_C:\\Users\\Wout\\Desktop\\WPF\\Oefeningen\\UnoGame2\\bin\\Debug\\Images\\UNOCards\\cardback.png��6$   $	��200��6�   5t      5v      �� 5w      $��1��6   $��2��6&   $	��100��6:   ��6F   �� *
PlayCard+.��6c   	Play card6n   5x      �� 5y      $��3��6   ��6'   �� *Logs+��5z      �� 5{      " ��6   .�5|      �� 
 � ��
 �����6G   �� 5}      
 � ��$ 15(�65   6B   �� 5~      
 � ��$ DemiBold"�67   6J   5      5�      �� 5�      $��4��6   ��6'   �� *Bot3+��5�      �� 5�      .R�5�      A� $ 1��6&   5�      ��5�      �� 5�      .R�5�      �� $��0q�6    $e��_C:\\Users\\Wout\\Desktop\\WPF\\Oefeningen\\UnoGame2\\bin\\Debug\\Images\\UNOCards\\cardback.png��6+   $	��100��6�    5�      �� 5�   "   $ 25Q�62   $ 25Q�6?   $	 270Q�6L   5�      5�      5�      5�      5�      5�      