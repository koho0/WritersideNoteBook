# Git程式碼

<primary-label ref="git"/>
<secondary-label ref="2024.09.25"/>
<secondary-label ref="beta"/>
<secondary-label ref="experimental"/>

## 推送项目到github
```Bash
# 初始化本地 Git 倉庫
git init

# 添加所有檔案到暫存區
git add .

# 提交變更
git commit -m "第一次提交"

# 連接遠端倉庫
git remote add origin https://github.com/koho0/WritersideNote

# 推送變更
git push -u origin main
```
{collapsible="true" collapsed-title="推送项目到github"}

```Bash
# 设置全局 Git 用户名
git config --global user.name "Your Name"

# 设置全局 Git 邮箱
git config --global user.email "your.email@example.com"
```
{collapsible="true" collapsed-title="设置git用户名"}
