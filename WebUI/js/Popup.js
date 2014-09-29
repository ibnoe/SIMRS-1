var version4 = (navigator.appVersion.charAt(0) == "4");
var popupHandle;
function closePopup() {
if(popupHandle != null && !popupHandle.closed) popupHandle.close()
}
function displayPopup_scroll(position,url,name,height,width,evnt)
{
	var properties = "toolbar=0,location=0,resizable=1,scrollbars=1,height="+height
	properties = properties+",width="+width
	var leftprop, topprop, screenX, screenY, cursorX, cursorY, padAmt
	if(navigator.appName == "Microsoft Internet Explorer")
	{
		screenY = document.body.offsetHeight
		screenX = window.screen.availWidth
	}
	else
	{ 
		screenY = window.outerHeight
		screenX = window.outerWidth
		screenY = screen.height;
		screenX = screen.width;
	}
	if(position == 1)
	{
		cursorX = evnt.screenX
		cursorY = evnt.screenY
		padAmtX = 10
		padAmtY = 10
		if((cursorY + height + padAmtY) > screenY)	
		{
			padAmtY = (-30) + (height*-1);	
		}
		if((cursorX + width + padAmtX) > screenX)
		{
			padAmtX = (-30) + (width*-1);	
		}
		if(navigator.appName == "Microsoft Internet Explorer")
		{
			leftprop = cursorX + padAmtX
			topprop = cursorY + padAmtY
		}
		else
		{ 
			leftprop = (cursorX - pageXOffset + padAmtX)
			topprop = (cursorY - pageYOffset + padAmtY)
		}
	}
	else
	{
		leftvar = (screenX - width) / 2
		rightvar = (screenY - height) / 2
		if(navigator.appName == "Microsoft Internet Explorer")
		{
			leftprop = leftvar
			topprop = rightvar //+170
		}
		else
		{
			leftprop = (leftvar - pageXOffset)
			topprop = (rightvar - pageYOffset)
		}
	}
	if(evnt != null)
	{
		properties = properties+",left="+leftprop
		properties = properties+",top="+topprop
	}
	closePopup()
	popupHandle = open(url,name,properties)
}

function displayPopup_Disposed(position,url,name,height,width,evnt)
{
	var properties = "toolbar=0,location=0,resizable=1,scrollbars=1,height="+height
	properties = properties+",width="+width
	var leftprop, topprop, screenX, screenY, cursorX, cursorY, padAmt
	if(navigator.appName == "Microsoft Internet Explorer")
	{
		screenY = document.body.offsetHeight
		screenX = window.screen.availWidth
	}
	else
	{ 
		screenY = window.outerHeight
		screenX = window.outerWidth
		screenY = screen.height;
		screenX = screen.width;
	}
	if(position == 1)
	{
		cursorX = evnt.screenX
		cursorY = evnt.screenY
		padAmtX = 10
		padAmtY = 10
		if((cursorY + height + padAmtY) > screenY)	
		{
			padAmtY = (-30) + (height*-1);	
		}
		if((cursorX + width + padAmtX) > screenX)
		{
			padAmtX = (-30) + (width*-1);	
		}
		if(navigator.appName == "Microsoft Internet Explorer")
		{
			leftprop = cursorX + padAmtX
			topprop = cursorY + padAmtY
		}
		else
		{ 
			leftprop = (cursorX - pageXOffset + padAmtX)
			topprop = (cursorY - pageYOffset + padAmtY)
		}
	}
	else
	{
		leftvar = (screenX - width) / 2
		rightvar = (screenY - height) / 2
		if(navigator.appName == "Microsoft Internet Explorer")
		{
			leftprop = leftvar
			topprop = rightvar //+170
		}
		else
		{
			leftprop = (leftvar - pageXOffset)
			topprop = (rightvar - pageYOffset)
		}
	}
	if(evnt != null)
	{
		properties = properties+",left="+leftprop
		properties = properties+",top="+topprop
	}
	popupHandle = open(url,name,properties)
	closePopup()
}
