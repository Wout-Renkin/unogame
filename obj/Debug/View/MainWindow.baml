   M S B A M L   `   `   `  ����C  ?UnoGame2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:UnoGame2.ViewUnoGame2.View  5   	       UnoGame2.View.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   'localclr-namespace:UnoGame2.View  5   	     � Title$  
MainWindow��5
   	   $	��450��6   $	��800��6)    � DataContext 5	   	   ��    mainViewModelLocator �� Source# [   �� Path$ MainWindowViewModel���5      �� 5   
    �� ImageSource$ /Images/uno.jpg��6   .��5      �  � ColumnDefinitions 5   
   �� 5      $��3* �6   �� 5      $��3* �6   �� 5      $��3* �6    6-    � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��7* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone     Mode$ 
PrimaryMid=�6#   $��Stretch=�65   $	��Top=�6S   $��10q�6h   .��5      �� -   5        $��TextBlockTitel��5      
�������$��16(�6A   $��Center=�6P   ��6m   �� *Player.Nickname+ �� StringFormat$ Welcome {0}!��6�   5      )  #MaterialDesignThemes.Wpf.DialogHost  5    
   	   CloseOnClickAway	 . $��2��6<   $��1��6I   
   DialogContent
 5!      � 5"      $��20q�6    5#      �� 5$      $��7* �6(   �� 5%      $��7* �6(   �� 5&      $��7* �6(    5(      �� 5)      6-   �� 5*      6-   .+�5,        $��0��6/   $��2��6<   $ 
PrimaryMid=�6P   $��Stretch=�6b   $��10q�6�   $��0,0,0,30q�6�   .��5.      �� 
�������$��16(�67   $��Center=�6F   Amount of players6v   5/      �� 50      $��1��6   $��2��6,   $��0,0,0,40q�6@    �� SelectedValuePath$ Content��6z    �� SelectedValue 6R   �� *AmountPlayers+.@�51      �� .��6'   253      �� 54      .��6'   356      �� 57      .��6'   459      5:      �� 5;      $��2��6   $��0��6*   $��5q�6:   $
��Play��6E   ��6T   �� *PlayCommand+5=      �� 5>      $��2��6   $��1��6*      CloseDialogCommand#��Z 6:   $
��Back��6|   
����  �$��5q�6�   5?      .��5A      ��    OpenDialogCommand#��Z 6   $��1��6V   $��1��6c   $
��Play��6s   $	��200��6�   $	��Top=�6�   5B      �� 5C   
   $��3��6   $��Game history��6   $	��200��65   $��1��6A   ��6Q   �� *GameHistoryCommand+�� 5D   
   $��4��6   $��Change nickname��6   $	��200��68   $��1��6D   ��6U   �� *ChangeNicknameCommand+5H      5I      