   M S B A M L   `   `   `  ����B  >ATM APP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ATM_APPATM_APP  5   	       ATM_APP.Menuscreen   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   'localclr-namespace:ATM_APP     5   	     � Title$  
Menuscreen��5   	   $	��500��6   $	��720��6)   
����� � � WindowStartupLocation$ CenterScreen=�6G    � 	Resources 5         	mybtnstyl �� 
TargetType �� Property �� Value��%�   &	        �� 5   
   " ��6"   .�5   
   ��  � ��$ 40��6$   61   �� 5	       � ��
 �����6;   �� 5
       � ��$	 200��6&   64   �� 5       � ��$ 20(�6)   66   �� 5       � ��$ SemiBold"�6+   6>   5      5       � DataContext 5         ATM_APP.MenuViewModel  5   
   5      .��5      � .+�5   
   �� -   5         ��Name$ custnamelbl��5      
�������$��18(�6z   $��SemiBold"�6�   $��482,24,24.6,394.4q�6�   ��6&   �� *	Custlbl+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5   
   .+�5      �� -   5        	 ��Name$	 balbtn��5      $��Check Balance��6E   #��[  6]   $��	0,120,0,0q�6�   ��6%   �� *CmdCheckBal+6�   �� 5      -   5        $	 withdrawbtn��5      $��Withdraw Money��6M   #��[  6g   $��
20,20,20,0q�6�   ��6*   �� *CmdWithdrawAmt+6�   �� 5      -   5        $	 transferbtn��5      $��Transfer Money��6O   #��[  6i   $��SemiBold"�6�   $��
20,20,20,0q�6�   ��6*   �� *CmdTransferMoney+6�   �� 5      -   5        $	 pinchangebtn��5      $��
Change PIN��6J   #��[  6a   $��
20,20,20,0q�6�   ��6+   �� *
CmdChngPin+6�   �� 5      -   5        $	 ministmt_btn��5      $��Mini Statement��6P   #��[  6k   $��
20,20,20,0q�6�   ��6+   �� *CmdMiniStatement+6�   5      5!      5"      