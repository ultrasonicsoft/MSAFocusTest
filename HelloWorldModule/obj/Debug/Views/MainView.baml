   M S B A M L   `   `   `  ����K  GHelloWorldModule, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:HelloWorldModule.ViewsHelloWorldModule.Views  5      G(clr-namespace:HelloWorldModule.ViewModelHelloWorldModule.ViewModel  5	      $    MainFocusModule.Views.MainView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      >d2http://schemas.microsoft.com/expression/blend/2008    5      Hmc;http://schemas.openxmlformats.org/markup-compatibility/2006    5      4views$clr-namespace:HelloWorldModule.Views    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      >	viewModel(clr-namespace:HelloWorldModule.ViewModel     5	        � 	Resources  5
       �� 
TargetType �� Property �� Value��%�  '��       '�� �     '� o    �� 5   
   " ��6   .�5      ��  � ��$ 
10,0,10,10q�6'   �� 5       � ��$	 120��6&   �� 5       � ��$ 30��6'   64   �� 5       � ��$ 16(�6)   66   5      �� 5   
   " ��6   .�5      ��  � ��$ 
10,0,10,10q�6'   6<   �� 5       � ��$	 120��6&   64   �� 5       � ��$ 30��6'   64   5      �� 5   
   " �6   .�5      ��  � ��$ 0,0,5,5q�6'   69   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   .+�5!   
   �  5"      �� 5#      6"   �� 5$      6"   �� 5%      6"   �� 5&      6"    � ColumnDefinitions 5(      �� 5)      $
��Auto �6#   62   �� 5*      $��* �6#   6/   .+�5-      &   System.Windows.Controls.DataGrid  $��0��6   $��1��5.         	RowHeight$ 35Q�50      $��16(�51         CanUserAddRows . ��5/      �� *CustomerView+ � ContextMenu 54      �� 55      .@�56      m� $��Add Row��6#   m� 57      $��
Delete Row��6#   58      5:      �� 5<      $��0��6   $��0��5=      .+�5>      �� .��6   	Filter:6!   �� 5?      ��6   �� *
SearchText+	 �� UpdateSourceTrigger$	 PropertyChanged=�6]   �� 5@      ��6   �� 
 �� Path$
 LoadCustomersCommand�.��6G   Load Customers6W   �� 5A      ��6   �� $ 
 AddNewCustomControlCommand�.��6M   Load Custom Control6b   �� 5B      ��6   �� $#
 SetChildrenMessageTextCommand�.��6P   Set Custom Message6d   5C      5D      � 5F   
   $��1��6    5G      �� 5H      $
��Auto �6#   62   �� 5I      $
��Auto �6#   62   .+�5K      �� $��0��6    �� Orientation$ 
Horizontal=�5L      .+�5M      �� $ ��Send Message to Children: ��6   �� 5N      $	��150��6   ��5O      �� *ParentMessageText+5P      �� 5Q      $��1��6   $ 
Horizontal=�5R      .+�5S      �� $,��&Send Message to Child with Unique Id: ��6   �� 5T      $	��150��6   ��5U      �� *
UniqueId+5V      5W      �� 5Y   
   $��0��6   $��2��6#   ��60   �� *!FocusControlViewModelCollection+��5[      �� 5\      .R�5]      ,   &HelloWorldModule.Views.MSAFocusControl   � DataContext 6,   �� 5^      5`      5a      5b      