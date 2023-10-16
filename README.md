# ERGenerator
ERGenerator is to generate ER diagram from C# source code.
## topic
* Mermaid Markdown text definitions
* Use roslyn parser 
## Step.
1. Ddownload and build
2. Create Templatefile
 see download sample template
3. Execute
ERGenerator "Samples\Sample.tmpl" "Samples" "out.txt"
## ER Sample Diagram
```mermaid
erDiagram
Company ||--o{ Emp : emplyess
  Emp {
    int Id ""
    string LastName "姓"
    string FirstName "名"
    string ComapyId "CompanyId"
    DateTime CreatedDate ""
    DateTime UpdatedDate ""
  }
  Company {
    int Id ""
    string Name "CompanyName"
    string Address "CompanyAddress"
    string Tel "TEL"
    DateTime CreatedDate ""
    DateTime UpdatedDate ""
  }
```
