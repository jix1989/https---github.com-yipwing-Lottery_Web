<!--#include file="asp_md5.asp"-->
<!--#include file="setPayInfoConfig.asp"-->
<%

response.Charset="gb2312"
on error resume next'''HTTP�첽���亯��




dim parter'�̻�ID

dim banktype'��������

dim price'֧�����

dim orderid'�̻�������

dim callbackurl'֧���ص�ҳ��

dim hrefbackurl'֧����ɺ����תҳ��

dim sign'ǩ��

userkey=u_userkey'�̻���Կ���û������滻

parter=u_parter'�����̻�ID���û������滻

callbackurl=u_callbackurl' ֧���ص�ҳ��

hrefbackurl=u_hrefbackurl' ֧����ת��ҳ��

price=Trim(request("Price2"))'֧�����

bankid=Trim(request("bankid"))'���п�ID

orderid = Trim(request("orderid"))

if orderid = "" then
	Randomize 
	rnds = Int((900 * Rnd) + 100)
	orderid=year(now())&month(now())&day(now())&hour(now())&minute(now())&second(now())&rnds''''�����̻�������,�̻������ж���
end if

if price = "" or not(isnumeric(price)) then
	response.Write "��ѡ���ֵ�Ľ��"
	response.End()
end if

sign=asp_md5("parter="&parter&"&type="&bankid&"&value="&price&"&orderid="&orderid&"&callbackurl="&callbackurl&userkey)

url = u_sendurl

sendurl = url & "?type="&bankid&"&parter="&parter&"&value="&price&"&orderid="&orderid&"&callbackurl="&callbackurl&"&hrefbackurl="&hrefbackurl&"&sign="&sign

response.Redirect sendurl
response.End()
%>