		var newscharts=document.getElementsByClassName('newscharts')[0];
		var lis=document.querySelectorAll('.newscharts li');
		var spans=document.querySelectorAll('.circle span');
		// var leftBtn=document.getElementsByClassName('leftBtn')[0];
		// var rightBtn=document.getElementsByClassName('rightBtn')[0];
		var leftBtn=document.querySelector('.leftBtn');
		var rightBtn=document.querySelector('.rightBtn');

		var cn=0;	//当前次点击对应的索引
		var ln=0;	//上一次选中的图片对应的索引

		for(var i=0;i<spans.length;i++){
			spans[i].index=i;
			spans[i].onclick=function(){
				cn=this.index;
				/* //console.log(this.index);

				lis[ln].className='';
				lis[cn].className='active';

				spans[ln].className='';
				spans[cn].className='active';

				//lis[ln].className=spans[ln].className='';
				//lis[cn].className=spans[cn].className='active';

				ln=cn;	//当前次点击的索引相对于下一次点击来说就是上一次的索引 */

				change();
			};
		}

		function change(){
			lis[ln].className=spans[ln].className='';
			lis[cn].className=spans[cn].className='active';
			ln=cn;
		}

		leftBtn.onclick=function(){
			cn--;
			if(cn<0){
				cn=lis.length-1;
			}
			change();
			clearInterval(window.timer)

		};

		rightBtn.onclick=function(){
			cn++;
			if(cn>lis.length-1){
				cn=0;
			}
			change();
			clearInterval(window.timer)

		};

		var timer=setInterval(rightBtn.onclick,3000);

		newscharts.onmouseover=function(){
			leftBtn.style.display=rightBtn.style.display="block";
			clearInterval(window.timer);


		};
		newscharts.onmouseout=function(){
			leftBtn.style.display=rightBtn.style.display="none";
			timer=setInterval(rightBtn.onclick,3000);
		};