   M S B A M L   `   `   `  ����E  AChatClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ChatAppCourseChatAppCourse  5   	   E'clr-namespace:ChatClient.MVVF.ViewModelChatClient.MVVF.ViewModel  5   	       ChatAppCourse.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:ChatAppCourse     5   	   =	viewmodel'clr-namespace:ChatClient.MVVF.ViewModel     5   	     � Title$  
MainWindow��5	   	    � SizeToContent$ WidthAndHeight=�5
   	    � 
ResizeMode$ NoResize=�5   	   $	��500��5   	   $	��300��5   	   $��Roboto)�5   	   $��13(�5   	      BackgroundBrush#���   5   	     ForegroundBrush#���  5   	    � DataContext 5      -  'ChatClient.MVVF.ViewModel.MainViewModel  5   
   .��5      ]� #���   6   .+�5   
   d� -   5        $��60��5      $��30��6"   $��10q�6.   $	��Top=�6:   ��5      �� 5      .R�5      ��  ��Name$ SwitchBorder��6   $��58��63   $��30��6>    �� CornerRadius$ 15��6J   #���   6\   ._�5      �� $ SwitchShape��6!   $��22��66   $��22��6A   $��4,0,4,0q�6M   
�������$
��Left=�5    !   $ 15��6<    J� Effect 5!      3  -System.Windows.Media.Effects.DropShadowEffect  5"   "      Opacity$ .2Q�63   5$      5%       �� Triggers 5&      P� 5'      	 P� Property	 �@d�	IsChecked
 P� Value$

 TrueY�6D   . �5(      ��  �� 
TargetName$ SwitchShape��6%    �� Property � �� �� Value$ Right=�6]   �� 5)      $ SwitchBorder��6%    � �� �#4cd9646U   5*      P� 5+      	 �@d�	IsChecked$
 FalseY�6D   . �5,      �� $ SwitchBorder��6%    � ��
 �����6U   5-      5/      51      � 53   
   #���   6   $	��Top=�6>    � ColumnDefinitions 54      �� 55      $	��200 �6#   �� 56      .+�59      ]� #���   6   .+�5:      �� $��25��6   $	��Top=�5;      $��Center=�5<      $��Center=�5=      #���   5?      #���  5@      ��5>      �� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=�5@      �� 5A      $��25��6   $��14(�5B      $
��Bold"�5C      $	��Top=�5D      $��Connect��5E        ConnectButtonStyle#��[ 5G      ��5F      �� *ConnectToServerCommand+5G      �� 5H      #���   5I      #���  5J      ��5H      �� *Users+��5K      �� 5L      .R�5M      �� #���   5N   (   #���  5O   (   ��5M   (   �� *
Username+5O   (   5P      5R      5S      �� 5U      $��1��6   #���   6)   .+�5V      �� -   5         ��Name$ MessagesScrollViewer��5V      $
��Auto=�6=   .��5W      �� -   5        $��MessagesListView��5W      $	��380��5X      #���   5Z      #���  5[      ��5Y      �� *
Messages+5[      5\      �� 5]       �� Orientation$ 
Horizontal=�6   #���   66   .+�5^      �� -   5         ��Name$ MessageTextBox��5^      $��55��5_      $	��545��5`      $��Center=�5a      $��Center=�5b      #���   5e      #���  5f      ��5c      �� *	Message+$ PropertyChanged=�{�5g      �� *IsConnected+�� 5h      -   5        $��55��5h      $
��Bold"�5i      $��14(�5j      $
��Send��5k      #��[ 5m      ��5l      �� *SendMessageCommand+{�5n      �� *IsConnected+5o      5p      5q      5s      5t      5u      