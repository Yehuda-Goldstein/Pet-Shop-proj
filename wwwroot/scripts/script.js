function CategorySelected(){
    let id = document.getElementById("CategoryList").value;
    window.location.href = "/Catalog/CatalogPage/" + id;
}
function AdminCategorySelected() {
    let id = document.getElementById("CategoryList").value;
    window.location.href = "/Admin/AdminPage/" + id;
}