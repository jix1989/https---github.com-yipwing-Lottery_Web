<title>����������ֵ</title>
<style>
*{ font-family:Arial, Helvetica, sans-serif;
font-size:12px}
.STYLE1 {font-size: 12px}
</style>
<div style="text-align:center">
  <h2>��ѡ���ֵ��ʽ</h2>
</div>

<form name="form1" action="sendbank.asp" method="post" target="_blank">
  <table width="498" border="0" align="center" cellpadding="0" cellspacing="0" style="border:#99CC00 solid 2px">
    <tr>
      <td height="407" colspan="2" align="center" bordercolor="#00CCFF"><table width="68%" border="0" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC">
      
	  <tr>
          <td width="32%" height="25" align="left" bgcolor="#FFFFFF"><input type="radio" name="bankid" value="992"  />
֧����</td>
          <td width="32%" align="left" bgcolor="#FFFFFF"><input type="radio" name="bankid" value="1004" />
΢��</td>
          </tr>
        <tr>
          <td width="32%" height="25" align="left" bgcolor="#FFFFFF"><input type="radio" name="bankid" value="964"  />
�й�ũҵ����</td>
          <td width="32%" align="left" bgcolor="#FFFFFF"><input type="radio" name="bankid" value="968" />
��������</td>
          </tr>
        <tr>
          <td height="25" align="left" bgcolor="#FFFFFF"><input type="radio" name="bankid" value="965" />
            �й���������</td>
          <td align="left" bgcolor="#FFFFFF"><input name="bankid" type="radio" value="967" checked="checked" />
            �й���������</td>
          </tr>
        <tr>
          <td height="25" align="left" bgcolor="#FFFFFF"><input type="radio" name="bankid" value="969" />
            �㽭������ҵ����</td>
          <td align="left" bgcolor="#FFFFFF"><input type="radio" name="bankid" value="970" />
            ��������</td>
          </tr>
        <tr>
          <td height="25" align="left" bgcolor="#FFFFFF"><input type="radio" name="bankid" value="972" />
            ��ҵ����</td>
          <td align="left" bgcolor="#FFFFFF"><input type="radio" name="bankid" value="973"  />
            ˳��ũ�����ú�����</td>
          </tr>
        <tr>
          <td height="25" align="left" bgcolor="#FFFFFF"><input type="radio" name="bankid" value="975" />
            �Ϻ�����</td>
          <td align="left" bgcolor="#FFFFFF"><input type="radio" name="bankid" value="976" />
            �Ϻ�ũ����ҵ����</td>
          </tr>
        <tr>
          <td height="25" align="left" bgcolor="#FFFFFF"><input type="radio" name="bankid" value="978" />
            ƽ������</td>
          <td align="left" bgcolor="#FFFFFF"><input type="radio" name="bankid" value="980" />
            ��������</td>
          </tr>
        <tr>
          <td height="25" align="left" bgcolor="#FFFFFF"><input type="radio" name="bankid" value="982" />
            ��������</td>
          <td align="left" bgcolor="#FFFFFF"><input type="radio" name="bankid" value="983" />
            ��������</td>
          </tr>
        <tr>
          <td height="25" align="left" bgcolor="#FFFFFF"><input type="radio" name="bankid" value="985" />
            �㶫��չ����</td>
          <td align="left" bgcolor="#FFFFFF"><input type="radio" name="bankid" value="986" />
            �������</td>
          </tr>
        <tr>
          <td height="25" align="left" bgcolor="#FFFFFF"><input type="radio" name="bankid" value="988" />
            ��������</td>
          <td align="left" bgcolor="#FFFFFF"><input type="radio" name="bankid" value="989" />
            ��������</td>
          </tr>
        <tr>
          <td height="25" align="left" bgcolor="#FFFFFF"><input type="radio" name="bankid" value="979" />
            �Ͼ�����</td>
          <td align="left" bgcolor="#FFFFFF"><input name="bankid" type="radio"  value="962" />
��������</td>
          </tr>
        <tr>
          <td height="25" align="left" bgcolor="#FFFFFF"><input type="radio" name="bankid" value="963"  />
�й�����</td>
          <td align="left" bgcolor="#FFFFFF"><input type="radio" name="bankid" value="991"  />
����ũ����ҵ����</td>
          </tr>
        <tr>
          <td height="25" align="left" bgcolor="#FFFFFF"><input type="radio" name="bankid" value="987"  />
��������</td>
          <td align="left" bgcolor="#FFFFFF"><input type="radio" name="bankid" value="984"  />
������ũ��������</td>
          </tr>
        <tr>
          <td height="25" align="left" bgcolor="#FFFFFF"><input type="radio" name="bankid" value="981"  />
��ͨ����</td>
          <td align="left" bgcolor="#FFFFFF"><input type="radio" name="bankid" value="977"  />
�ֶ���չ����</td>
          </tr>
        <tr>
          <td height="25" align="left" bgcolor="#FFFFFF"><input type="radio" name="bankid" value="974" />
���ڷ�չ����</td>
          <td align="left" bgcolor="#FFFFFF"><input type="radio" name="bankid" value="971" />
��������</td>
          </tr>

            <tr>
          <td height="25" align="left" bgcolor="#FFFFFF"><input type="radio" name="bankid" value="2097" />
����WAP</td>
          <td align="left" bgcolor="#FFFFFF"><input type="radio" name="bankid" value="1006" />
֧����WAP</td>
          </tr>
           <tr>
          <td height="25" align="left" bgcolor="#FFFFFF"><input type="radio" name="bankid" value="1007" />
΢��WAP</td>
          <td align="left" bgcolor="#FFFFFF"></td>
          </tr>

      </table></td>
    </tr>
    <tr>
      <td width="111" height="27" align="center">��д���</td><td width="383">

      <input name="Price2" type="text" size="10" maxlength="10" value="100" />

        Ԫ</td>
    </tr>
    <tr>
      <td height="36" colspan="2" align="center"><input type="submit" name="submit2" value="ȷ�ϸ���" onclick="return checkMoney()" />  <a href="../testcard/index.asp"  target="_blank"/>�㿨��ֵ</a></td>
    </tr>
  </table>
  <input type="hidden" name="orderid" value="<%=num%>">
</form>
<script language="javascript">
function checkMoney(){
	if(document.form1.Price2.value ==""){
		alert('�������ֵ�Ľ��');
		return false
	}
}
</script>