# CSS程式码
<primary-label ref="css"/>
<secondary-label ref="2024.09.25"/>
<secondary-label ref="beta"/>
<secondary-label ref="experimental"/>

## 自定义滚动条
```CSS
        #toolbarDiv::-webkit-scrollbar {
            width: 25px;
        }

        #toolbarDiv::-webkit-scrollbar-track {
            background: rgba(30, 159, 255, 0.2);
            border-radius: 10px;
        }

        #toolbarDiv::-webkit-scrollbar-thumb {
            background: rgba(30, 159, 255, 0.5);
            border-radius: 10px;
        }

            #toolbarDiv::-webkit-scrollbar-thumb:hover {
                background: #1e9fff;
            }
```
{collapsible="true" collapsed-title="自定义滚动条"}

## 自定义弹窗
```CSS
/* 弹窗背景遮罩 */
.custom-popup-overlay {
    display: none;
    position: fixed;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    z-index: 999;
}

/* 弹窗样式 */
.custom-popup {
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    background: #fff;
    padding: 20px;
    border-radius: 10px;
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.3);
    text-align: center;
    z-index: 1000;
}

    .custom-popup p {
        font-size: 28px;
        color: #333;
    }
```
{collapsible="true" collapsed-title="自定义弹窗"}

## 自定义按钮和输入框流光效果
```CSS
 #alarm {
     flex-direction: column;
     align-items: center;
     margin: 20px;
     margin-top: 100px;
 }

     #alarm input {
         margin-bottom: 20px;
         width: 500px;
         height: 20px;
         padding: 30px;
         font-size: 26px;
         margin-left: 10px;
         border: 1px solid #ddd;
         transition: border-color 0.3s ease;
         border-radius: 15px;
     }

         /* 输入框获得焦点时的样式 */
         #alarm input:focus {
             border-color: #1e9fff;
             outline: none;
             animation: glow 1s ease-in-out infinite;
         }

     #alarm .layui-btn {
         padding: 25px 30px;
         margin: 15px 10px;
         height: 6rem;
         width: 14rem;
         border-radius: 15px;
         font-size: 28px;
         font-weight: bolder;
         word-wrap: break-word;
         overflow-wrap: break-word;
         white-space: normal;
         word-break: break-word;
     }
     
     
@@keyframes glow {
    0% {
        box-shadow: 0 0 5px 3px rgba(30, 159, 255, 0.5);
    }

    50% {
        box-shadow: 0 0 10px 5px rgba(30, 159, 255, 0.8);
    }

    100% {
        box-shadow: 0 0 5px 3px rgba(30, 159, 255, 0.5);
    }
}
```
{collapsible="true" collapsed-title="自定义按钮和输入框"}