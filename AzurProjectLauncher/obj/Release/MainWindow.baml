   M S B A M L   `   `   `  ���� N  JAzurProjectLauncher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:AzurProjectLauncherAzurProjectLauncher  $    AzurProjectLauncher.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     3local!clr-namespace:AzurProjectLauncher     -     �Name$  LauncherWindow�� � Title$ Azur Project Launcher��$��223.562��$��344.745�� � Icon$ Icon.png��
������� � 
ResizeMode$ NoResize=�.��� 
�������$��0q�$	��319��$	��175�� � RowDefinitions �� $
��Auto ���  � ColumnDefinitions �� .+��� -    ��Name$ LaunchGameButton��$��	Play Game��$��	10,0,0,10q�$��0q����	#FF336699
�������$
��Bold"�$��Bottom=�$��40��$��18(�$
��Left=�$	��140��$��1��$��Diogenes)���Z� �� -    ��Name$ image��$��Center=�$��10q�$��Center=�$��GameTitle.png��$��70��$	��300���� -   $ LaunchGameButton_Copy��$��Force Update��$��0q����	#FF336699
�������$
��Bold"�$��Bottom=�$
��Left=�$	��140��$��40��$��1��$��16(�$��
169,0,0,10q�$��Diogenes)���Z� �� -   $ BrowseInstallDirectory��$	��...��$��Right=�$��0,1,10,0q�$��1��$	��Top=�$��24��$��20���� -    ��Name$ labelGameInstallPath��$�� ��$
��Left=�$��10,0,0,0q�$	��Top=�$��10(�$��23��$	��270��$��1��