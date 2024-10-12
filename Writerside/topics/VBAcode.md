# VBA程式碼

<primary-label ref="vba"/>
<secondary-label ref="2024.09.25"/>
<secondary-label ref="beta"/>
<secondary-label ref="experimental"/>

```VB
Sub AddBordersToAllPictures()
Dim inshape As InlineShape
Dim myPic As Shape

    ' 關閉屏幕更新以加快宏的執行速度
    Application.ScreenUpdating = False

    ' 給嵌入式圖片添加邊框
    For Each inshape In ActiveDocument.InlineShapes
        With inshape.Borders
            .OutsideLineStyle = wdLineStyleSingle ' 設置邊框樣式
            .OutsideColorIndex = wdColorAutomatic ' 設置邊框顏色
            .OutsideLineWidth = wdLineWidth025pt ' 設置邊框寬度
        End With
    Next inshape

    ' 給普通圖片添加邊框
    For Each myPic In ActiveDocument.Shapes
        If myPic.Type = msoPicture Then
            myPic.Line.Weight = 0.25 ' 設置邊框寬度
            myPic.Line.Style = msoLineSingle ' 設置邊框樣式
            myPic.Line.ForeColor.RGB = RGB(0, 0, 0) ' 設置邊框顏色
        End If
    Next myPic

    ' 重新啓用屏幕更新
    Application.ScreenUpdating = True
End Sub
```
{collapsible="true" collapsed-title="給圖片設置邊框"}
