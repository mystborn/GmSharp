---
layout: default
title: file_set_last_access_time
---

# file_set_last_access_time

[\[global\]]({{site.baseurl}}/docs/).[TaffyScript]({{site.baseurl}}/docs/TaffyScript/).[IO]({{site.baseurl}}/docs/TaffyScript/IO/).[file_set_last_access_time]({{site.baseurl}}/docs/TaffyScript/IO/file_set_last_access_time/)

_Sets the last access time of the specified file._

```cs
file_set_last_access_time(file_name, time)
```

## Arguments

<table>
  <col width="15%">
  <col width="15%">
  <thead>
    <tr>
      <th>Argument</th>
      <th>Type</th>
      <th>Description</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>file_name</td>
      <td>string</td>
      <td>The path of the file to set the last access time.</td>
    </tr>
    <tr>
      <td>time</td>
      <td>[DateTime]({{site.baseurl}}/docs/TaffyScript/DateTime)</td>
      <td>The date and time of the files last access.</td>
    </tr>
  </tbody>
</table>

**Returns:** null