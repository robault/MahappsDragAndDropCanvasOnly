   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.3.0.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	    MahappsDragAndDrop#   MahappsDragAndDrop.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   -   5          � Title$  
MainWindow��5   	   $	��600��6   $	��800��6)   (   "MahApps.Metro.Controls.MetroWindow   RightWindowCommands 5      +   %MahApps.Metro.Controls.WindowCommands  5   
   .@�5      �� -   5        $��SettingsButton��5      $��Drag and Drop��6+   6C   �� 5	      -   5        $��ResetButton��5	      $��Reset��6(   68   5
         Flyouts 5      +   %MahApps.Metro.Controls.FlyoutsControl  5   
   .@�5      #   MahApps.Metro.Controls.Flyout  -   5        $��SettingsFlyout��5         Header$  ��64      Position$ Right=�6>   5      5      .��5      � .+�5   
   �� -   5         ��Name$ DragList��5      
�������$	��100��6<   $��1q�6H   $��
-700,0,0,0q�6\   5      �� 5#   
   -   5         ��Name$ 
DropCanvas��5#      
������� J� 	AllowDrop . $	��700��5'      $��	100,0,0,0q�5(      5)      5*      