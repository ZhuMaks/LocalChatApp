   M S B A M L   `   `   `  ���� E  AChatClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ChatAppCourseChatAppCourse  E'clr-namespace:ChatClient.MVVF.ViewModelChatClient.MVVF.ViewModel      ChatAppCourse.MainWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -localclr-namespace:ChatAppCourse     =	viewmodel'clr-namespace:ChatClient.MVVF.ViewModel       � Title$  
MainWindow�� � SizeToContent$ WidthAndHeight=� � 
ResizeMode$ NoResize=�$	��500��$	��300��$��Roboto)�$��13(�   BackgroundBrush#���     ForegroundBrush#���   � DataContext -  'ChatClient.MVVF.ViewModel.MainViewModel  .��]� #���   .+�d� -   $��60��$��30��$��10q�$	��Top=����� .R���  ��Name$ SwitchBorder��$��58��$��30�� �� CornerRadius$ 15��#���   ._��� $ SwitchShape��$��22��$��22��$��4,0,4,0q�
�������$
��Left=�$ 15�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Opacity$ .2Q� �� Triggers P� 	 P� Property	 �@d�	IsChecked
 P� Value$

 TrueY�. ���  �� 
TargetName$ SwitchShape�� �� Property � �� �� Value$ Right=��� $ SwitchBorder�� � �� �#4cd964P� 	 �@d�	IsChecked$
 FalseY�. ��� $ SwitchBorder�� � ��
 ������ #���   $	��Top=� � ColumnDefinitions �� $	��200 ��� .+�]� #���   .+��� $��25��$	��Top=�$��Center=�$��Center=�#���   #���  ���� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=��� $��25��$��14(�$
��Bold"�$	��Top=�$��Connect��  ConnectButtonStyle#��[ ���� *ConnectToServerCommand+�� #���   #���  ���� *Users+���� .R��� #���   #���  ���� *
Username+�� $��1��#���   .+��� -    ��Name$ MessagesScrollViewer��$
��Auto=�.���� -   $��MessagesListView��$	��380��#���   #���  ���� *
Messages+��  �� Orientation$ 
Horizontal=�#���   .+��� -    ��Name$ MessageTextBox��$��55��$	��545��$��Center=�$��Center=�#���   #���  ���� *	Message+$ PropertyChanged=�{��� *IsConnected+�� -   $��55��$
��Bold"�$��14(�$
��Send��#��[ ���� *SendMessageCommand+{��� *IsConnected+