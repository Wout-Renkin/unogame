   M S B A M L   `   `   `  ����C  ?UnoGame2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:UnoGame2.ViewUnoGame2.View  5   	        UnoGame2.View.ResultWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:UnoGame2.View     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  ResultWindow��5
   	   $	��200��6   $	��800��6+    � WindowStyle$
 None=�68    � DataContext 5	   	   ��    mainViewModelLocator �� Source# [   �� Path$ ResultWindowViewModel���5      �� 5   
    �� ImageSource$ /Images/background2i.jpg��6   .��5      �  � RowDefinitions 5   
   �� 5      $��2* �6   6*   �� 5      $��2* �6   6*   �� 5      $��2* �6   6*   .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone  $��0��6#      Mode$ 
PrimaryMid=�60   $��Stretch=�6B   $	��Top=�6`   $��10q�6u   .��5      �� -   5        $��TextBlockTitel��5      
�������$��16(�6A   $��Center=�6O   Result6t   5      �� 5   
   $��1��6   
�������$
��Bold"�64   $��16(�6F   $��Center=�6�   $��Center=�6�   ��6T   �� *Winner.Nickname+ �� StringFormat$  {0} won the game!��6�   �� 5   
   $��2��6   $	��200��6   ��6*   �� *BackMainMenu+.��6K   Back to main menu!5      5      5       