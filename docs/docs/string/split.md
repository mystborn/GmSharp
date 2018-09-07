---
layout: default
title: string.split
---

# string.split

[\[global\]]({{site.baseurl}}/docs/).[string]({{site.baseurl}}/docs/string/).[split]({{site.baseurl}}/docs/string/split/)

Based on a set of substrings, splits this string into an array.

```cs
string.split(..seperators, [remove_empty_entries = false])
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
      <td>..seperators</td>
      <td>strings</td>
      <td>Any number of strings that will be used to determine split borders.</td>
    </tr>
    <tr>
      <td>[remove_empty_entries = false]</td>
      <td>bool</td>
      <td>Optional value to used to determine if any empty strings should be removed from the resultant array.</td>
    </tr>
  </tbody>
</table>

**Returns:** array