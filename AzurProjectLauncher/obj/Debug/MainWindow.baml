   M S B A M L   `   `   `  ����N  JAzurProjectLauncher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:AzurProjectLauncherAzurProjectLauncher  5   	   $    AzurProjectLauncher.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:AzurProjectLauncher     5   	   -   5          �Name$  LauncherWindow��5   	    � Title$ Azur Project Launcher��5   	   $��223.562��6'   $��344.745��68    � Icon$ Icon.png��6H   
������� � 
ResizeMode$ NoResize=�6k   .��5	      � 
�������$��0q�6   $	��319��6)   $	��175��65    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5       � ColumnDefinitions 5   
   �� 5      .+�5   
   �� -   5         ��Name$ LaunchGameButton��5      $��	Play Game��6+   $��	10,0,0,10q�6?   $��0q�6R   ���	#FF336699
�������$
��Bold"�6�   $��Bottom=�6�   $��40��6�   $��18(�6�   $
��Left=�6  $	��140��6(  $��1��64  $��Diogenes)�6A  ��6f   Z� 6A  �� 5   
   -   5         ��Name$ image��5      $��Center=�6   $��10q�6<   $��Center=�6H   $��GameTitle.png��6c   $��70��6z   $	��300��6�   �� 5   
   -   5        $ LaunchGameButton_Copy��5      $��Force Update��60   $��0q�6G   ���	#FF336699
�������$
��Bold"�6�   $��Bottom=�6�   $
��Left=�6�   $	��140��6  $��40��6  $��1��6  $��16(�6*  $��
169,0,0,10q�68  $��Diogenes)�6L  ��6[   Z� 6L  �� 5   
   -   5        $ BrowseInstallDirectory��5      $	��...��61   $��Right=�6?   $��0,1,10,0q�6[   $��1��6m   $	��Top=�6z   $��24��6�   $��20��6�   �� 5   
   -   5         ��Name$ labelGameInstallPath��5      $�� ��6.   $
��Left=�69   $��10,0,0,0q�6T   $	��Top=�6f   $��10(�6~   $��23��6�   $	��270��6�   $��1��6�   5      5      