   M S B A M L   `   `   `  ����=  9UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:UIUI  5   	       UI.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   "localclr-namespace:UI     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   �� -   5         ��Name$ txtSearchStringValue��5
      $
��Left=�60   $��
192,77,0,0q�6K    �� TextWrapping$
 Wrap=�6_   $	��Top=�6s   $	��181��6�   $��21��6�    � 
InputScope$	 Url��6�   �� 5   
   $�� ��6   $
��Left=�6   $��	33,71,0,0q�66   $	��Top=�6I   �� 5   
   $��Enter string to search :��6   $
��Left=�63   $��	38,72,0,0q�6N   $	��Top=�6a   �� 5   
   $��Enter string to search :��6   $
��Left=�63   $��	38,72,0,0q�6N   $	��Top=�6a   �� 5   
   -   5         ��Name$ lblSearchString��5      $��Enter string to search :��6)   $
��Left=�6L   $��	38,72,0,0q�6g   $	��Top=�6z   $��Normal"�6�   �� 5   
   -   5        $ lblUrlSearch��5      $��Enter the url to match:��6&   $
��Left=�6H   $��
40,103,0,0q�6c   $	��Top=�6w   �� 5   
   -   5        $ txtSearchUrlValue��5      $
��Left=�6-   $��192,107,0,0q�6H   $
 Wrap=�6]   $	��Top=�6q   $	��181��6�   $ Default��6�   �� 5   
   -   5        $ lblCountText��5      $��Count of match:��6&   $
��Left=�6@   $��
73,134,0,0q�6[   $	��Top=�6o   �� 5   
   -   5        $ lblCountValue��5      $�� ��6'   $
��Left=�62   $��192,134,0,0q�6M   $	��Top=�6b   $	��128��6z   �� 5   
   -   5         ��Name$ btnHits��5      $��Get Hits��6"   $
��Left=�65   $��
430,94,0,0q�6P   $	��Top=�6d   $��55��6|   $��20��6�   6�   �� 5   
   -   5        $ lblErrorMessage��5      $�� ��6)   $
��Left=�64   $��127,168,0,0q�6O   $	��Top=�6d   �� 5   
   -	   5        $ btnReset��5      $��Reset��6#   $
��Left=�63   $��
500,94,0,0q�6N   $	��Top=�6b   6z   �� 5   
   -
   5        $ lblProcessing��5      $��Processing........��6'   $
��Left=�6D   $��
262,39,0,0q�6_   $	��Top=�6s   $y�Hidden=�6�   5      5      