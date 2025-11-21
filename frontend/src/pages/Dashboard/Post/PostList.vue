<script setup lang="ts">

import XLabel from "@/components/XLabel.vue";
import XButton from "@/components/XButton.vue";
</script>

<template>
  <div class="main">
    <div class="search">
      <input type="text" name="" id="">
      <XButton>搜索</XButton>
    </div>

    <table id="customers">
      <tr>
        <th>id</th>
        <th>文章标题</th>
        <th>文件分类</th>
        <th>创建时间</th>
        <th>修改时间</th>
        <th>作者</th>
        <th>操作</th>
      </tr>
      <tr>
        <td>1</td>
        <td>nihao</td>
        <td>hhh</td>
        <td>2025</td>
        <td>2025</td>
        <td>xiangxun</td>
        <td>我是操作</td>
      </tr>
    </table>

  </div>

</template>

<style scoped>
#customers {
  font-family: Arial, Helvetica, sans-serif;
  border-collapse: collapse;
  width: 100%;
}

#customers td, #customers th {
  border: 1px solid #ddd;
  padding: 8px;
}

#customers tr:nth-child(even){background-color: #f2f2f2;}

#customers tr:hover {background-color: #ddd;}

#customers th {
  padding-top: 12px;
  padding-bottom: 12px;
  text-align: left;
  background-color: #4CAF50;
  color: white;
}
</style>
