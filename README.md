# Extended Fluent Tag Builder
This project present wrapper for **System.Web.Mvc.TagBuilder** for implementing complex html structure.

Repository contains source code for extended version of tag builder and simple tests.
##Sample Usage
```
var htmlFactory = new HtmlFactory();
htmlFactory.Add("div")
	.Style("display", "block")
	.Class("base-item")
	.Inner(elements =>
	{
		elements.Add("span")
			.Class("header")
			.Text("Header");
		elements.Add("div")
			.Class("subheader")
			.Inner(inner =>
			{
				inner.Add("span")
					.Class("subheader-content")
					.Text("SubHeader");
			});
	});
	
var result = htmlFactory.ToString();
```
This code will produce a following result:
```
<div class="base-item" style="display:block;">
	<span class="header">Header</span>
	<div class="subheader">
		<span class="subheader-content">SubHeader</span>
	</div>
</div>
```