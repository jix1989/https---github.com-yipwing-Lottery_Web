<!--#include file="asp_md5.asp"-->
<!--#include file="merChat.asp"-->
<%
'***************************************����֧���㿨���ѽӿ�

'***************************************����ʱ�䣺2016-3-29

'***************************************�����ˣ���

dim orderid,opstate,sign,ovalue,userkey 
userkey = u_userkey'�̻���Կ
orderid = trim(request("orderid")) '�̻�������
opstate = trim(request("opstate")) '���ﷵ���̻�״̬
ovalue = trim(request("ovalue")) '���ﷵ��ʵ����ֵ
sign = trim(request("sign")) 'ǩ��
resulttime = trim(request("systime")) '���ﴦ�����ʱ��

'�����в�������ǩ����֤
signu = asp_md5("orderid="&orderid&"&opstate="&opstate&"&ovalue="&ovalue&userkey)

if signu<>sign then'��֤ʧ��
	response.Write "ǩ������"
	response.End()
end if

'opstate����״̬˵��
'opstate = 0,�����ɹ�ʹ��
'opstate = -1,�����������
'opstate = -2,��ʵ����ֵ���ύʱ��ֵ����������ʵ����ֵδʹ��
'opstate = -3,ʵ����ֵ���ύʱ��ֵ����������ʵ����ֵ�ѱ�ʹ�á���ʵ����ֵ��ovalue��ʾ
'opstate = -4,���Ѿ�ʹ�ã������ύ����������֮ǰ�Ѿ���ʹ�ã�
if cint(opstate) = 0 then
'֧���ɹ����ɽ����̻������߼�����
	response.Write "opstate=0"'�̻����յ������֪ͨ�Ժ���Ҫ��ҳ�������opstate=0����ʾ���յ�֪ͨ�����ﲻ���ڼ�������֪ͨ��
	response.End()
else
'֧��ʧ�ܣ��ɽ����̻������߼�����
	response.Write "opstate=0"'�̻����յ������֪ͨ�Ժ���Ҫ��ҳ�������opstate=0����ʾ���յ�֪ͨ�����ﲻ���ڼ�������֪ͨ��
	response.End()
end if
%>