   M S B A M L   `   `   `  ����B  >ATM APP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ATM_APPATM_APP  5   	       ATM_APP.MiniStatement   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   )local11clr-namespace:ATM_APP     5   	     � Title$  MiniStatement��5   	   $	��300��6   $	��600��6,   
����� � � WindowStartupLocation$ CenterScreen=�6J    � DataContext 5      $   ATM_APP.ministatementViewModel  5   
   6+   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5        $��
mydatagrid��5
      $	��600��6%   $	��200��61   $��Bottom=�6d      AutoGenerateColumns .     AlternatingRowBackground
 �����$��0,0,-6.4,66.4q�6�   ��6?   �� *transactions+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6j      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6v   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6&   �� 	 �� Path$
	 t_id�
 �� UpdateSourceTrigger$
 PropertyChanged=�6�     5      $ CArd_NO��6p   $	 100 6�    6'   �� $	 	card_no_t�$
 PropertyChanged=�6�     5      $ T_DATE��6k   $	 130 6{    6%   �� $	 tdate�$
 PropertyChanged=�6�     5      $
 DESC��6i   $	 100 6w    6%   �� $
	 desc�$
 PropertyChanged=�6�     5      $ AMOUNT��6h   $	 100 6x    6%   �� $		 amt�$
 PropertyChanged=�6�     5      $	 BAL��6h   $	 100 6u    6%   �� $		 bal�$
 PropertyChanged=�6�   5      �� 5   
   -   5        $��loadbtn��5      $��LOAD TRANSACTIONS��6    $	��150��6a   $��30��6n   $��221,217,222.6,23.4q�6z   ��6<   �� *CmdMinistatement+6�   5      5       