   M S B A M L   `   `   `  ����B  >ATM APP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ATM_APPATM_APP  5   	       ATM_APP.PINChange   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   &lpinclr-namespace:ATM_APP     5   	     � Title$  	PINChange��5   	   $	��400��6   $	��600��6(   
����� � � WindowStartupLocation$ CenterScreen=�6F    � DataContext 5         ATM_APP.ViewModel  5   
   6   .��5	   
   � .+�5
   
   �� $��OLD PIN��6   $��153,95,27.6,4.4q�6#   $��20(�6<   
�������$��SemiBold"�6]   6u   �� 5   
   $��NEW PIN��6   $��149,150,27.6,0.4q�6"   $��20(�6<   
�������$��SemiBold"�6^   6v   �� 5   
   $��0,1,-0.4,-0.6q�6   .+�5   
   �� -   5        $��	oldpintxt��5      $��22(�6;   $	��100��6I   $��32��6U   $��	0,100,0,0q�6a   ��6#   �� *OldPin+6w   �� 5      -   5        $��	newpintxt��5      $��22(�6'   $	��100��6M   $��32��6Y   $��247,20,246.6,20q�6e   ��65   �� *NewPin+6�   �� 5      -   5        $��	Changebtn��5      $��22(�6&   $��
Change PIN��6V   $	��130��6k   $��37��6w   $��0q�6�   
���������65   �� *CmdChangePIN+6�   5      5      5      