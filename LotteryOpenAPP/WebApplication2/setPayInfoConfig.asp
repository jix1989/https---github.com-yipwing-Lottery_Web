<%
Dim u_parter'�̻�ID

Dim u_userkey'ͨ����Կ

Dim u_callbackurl'֧���ص�ҳ��

Dim u_hrefbackurl'֧����ɺ���ת��ҳ��

Dim u_sendurl'�ύ��ַ���滻

'�̻�ID��֧��ʱ���滻Ϊ��ʽ���̻�ID
u_parter = 123

'֧����Կ��֧��ʱ���滻��ʽ����Կ
u_userkey = "123"

' ֧���ص�ҳ��
u_callbackurl = "http://"&Request.ServerVariables("SERVER_NAME")&"/callback.asp"

'֧����ɺ���ת��ҳ��
u_hrefbackurl = "http://"&Request.ServerVariables("SERVER_NAME")&"/hrefback.asp"' ֧����ת��ҳ��

'�ύ��ַ���滻
u_sendurl = "http://pay.0n2.com/bank/"
%>