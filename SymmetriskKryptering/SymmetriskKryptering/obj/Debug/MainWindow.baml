   M S B A M L   `   `   `  ����O  KSymmetriskKryptering, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:SymmetriskKrypteringSymmetriskKryptering  5   	   %    SymmetriskKryptering.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:SymmetriskKryptering     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��600��6)   .��5	      � .+�5
   
   �� -   5         ��Name$ comboBox��5
      $
��Left=�6%   $��	75,45,0,0q�6@   $	��Top=�6S   $	��120��6k    �� SelectedIndex$ 0��6w   .@�5      �� $	��DES��6   �� 5      $
��3DES��6   �� 5      $��Rijndael��6   5      �� 5   
   -   5         ��Name$ GenerateKeyAndVIBTN��5      $��Generate Key and VI��6.   $
��Left=�6L   $��
75,102,0,0q�6g   $	��Top=�6{   $	��120��6�   $��30��6�   6�   �� 5   
   -   5        $ 
EncryptBTN��5      $��Encrypt��6%   $
��Left=�67   $��
75,187,0,0q�6R   $	��Top=�6f   $	��120��6~   $��30��6�   6�   �� 5   
   -   5        $ 
DecryptBTN��5      $��Decrypt��6%   $
��Left=�67   $��
75,222,0,0q�6R   $	��Top=�6f   $	��120��6~   $��30��6�   6�   �� 5   
   -   5        $ GetEncryptTimeBTN��5      $��Get Encrypt Time��6,   $
��Left=�6G   $��
75,323,0,0q�6b   $	��Top=�6v   $	��120��6�   $��30��6�   6�   �� 5   
   -   5        $ GetDecryptTimeBTN��5      $��Get Decrypt Time��6,   $
��Left=�6G   $��
75,358,0,0q�6b   $	��Top=�6v   $	��120��6�   $��30��6�   6�   �� 5   
   -   5         ��Name$ keyTXT��5      $
��Left=�6"   $��23��6=   $��
374,39,0,0q�6I    �� TextWrapping$
 Wrap=�6]   $	��Top=�6q   $	��200��6�   �� 5   
   -   5        $ viTXT��5      $
��Left=�6!   $��23��6<   $��
374,93,0,0q�6H   $
 Wrap=�6\   $	��Top=�6p   $	��200��6�   �� 5   
   -	   5        $ plainASCIITXT��5      $
��Left=�6)   $��23��6D   $��374,147,0,0q�6P   $
 Wrap=�6e   $	��Top=�6y   $	��200��6�   �� 5   
   -
   5        $ plainHexTXT��5      $
��Left=�6'   $��23��6B   $��374,175,0,0q�6N   $
 Wrap=�6c   $	��Top=�6w   $	��200��6�   �� 5   
   -   5        $ chiperASCIITXT��5      $
��Left=�6*   $��23��6E   $��374,229,0,0q�6Q   $
 Wrap=�6f   $	��Top=�6z   $	��200��6�   �� 5   
   -   5        $ chiperHexTXT��5      $
��Left=�6(   $��23��6C   $��374,257,0,0q�6O   $
 Wrap=�6d   $	��Top=�6x   $	��200��6�   �� 5   
   $	��Key��6   $
��Left=�6   $��
374,13,0,0q�69   $	��Top=�6M   �� 5   
   $��VI��6   $
��Left=�6   $��
374,67,0,0q�68   $	��Top=�6L   �� 5   
   $��
Plain Text��6   $
��Left=�6%   $��374,121,0,0q�6@   $	��Top=�6U   �� 5   
   $��Chiper Text��6   $
��Left=�6&   $��374,203,0,0q�6A   $	��Top=�6V   �� 5   
   -   5         ��Name$ 
encryptLBL��5      $"��Time/message at encryption: ��6$   $
��Left=�6K   $��300,323,0,0q�6f   $	��Top=�6{   $��30��6�   $	��284��6�   �� 5   
   -   5        $ 
decryptLBL��5      $"��Time/message at decryption: ��6$   $
��Left=�6K   $��300,358,0,0q�6f   $	��Top=�6{   $��30��6�   $	��284��6�   �� 5    
   $��ASCII��6   $
��Left=�6    $��331,144,0,0q�6;   $	��Top=�6P   �� 5!   
   $	��HEX��6   $
��Left=�6   $��331,172,0,0q�69   $	��Top=�6N   �� 5"   
   $��ASCII��6   $
��Left=�6    $��331,226,0,0q�6;   $	��Top=�6P   �� 5#   
   $	��HEX��6   $
��Left=�6   $��331,254,0,0q�69   $	��Top=�6N   5%      5&      