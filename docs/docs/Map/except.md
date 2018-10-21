---
layout: default
title: Map.except
---

# Map.except

[\[global\]]({{site.baseurl}}/docs/).[Map]({{site.baseurl}}/docs/Map/).[except]({{site.baseurl}}/docs/Map/except/)

_Gets the set difference between this and another sequence._

```cs
Map.except(other, [comparer])
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
      <td>other</td>
      <td>Enumerable</td>
      <td>The other sequence used to get the difference.</td>
    </tr>
    <tr>
      <td>[comparer]</td>
      <td>EqualityComparer</td>
      <td>A comparer used to compare the elements in the sequences.</td>
    </tr>
  </tbody>
</table>

**Returns:** Enumerable