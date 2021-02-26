using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Migrations
{
    public partial class inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    categoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryName = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    picture = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.categoryID);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    customerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    companyName = table.Column<string>(nullable: true),
                    contactName = table.Column<string>(nullable: true),
                    contactTitle = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    region = table.Column<string>(nullable: true),
                    postalCode = table.Column<string>(nullable: true),
                    country = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    fax = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.customerID);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    employeeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lastName = table.Column<string>(nullable: true),
                    firstName = table.Column<string>(nullable: true),
                    title = table.Column<string>(nullable: true),
                    titleOfCourtesy = table.Column<string>(nullable: true),
                    birthDate = table.Column<DateTime>(nullable: false),
                    hireDate = table.Column<DateTime>(nullable: false),
                    address = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    region = table.Column<string>(nullable: true),
                    postalCode = table.Column<string>(nullable: true),
                    country = table.Column<string>(nullable: true),
                    homePhone = table.Column<string>(nullable: true),
                    extension = table.Column<string>(nullable: true),
                    photo = table.Column<string>(nullable: true),
                    notes = table.Column<string>(nullable: true),
                    reportsTo = table.Column<int>(nullable: true),
                    photoPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.employeeID);
                    table.ForeignKey(
                        name: "FK_employees_employees_reportsTo",
                        column: x => x.reportsTo,
                        principalTable: "employees",
                        principalColumn: "employeeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "region",
                columns: table => new
                {
                    regionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    regionDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_region", x => x.regionID);
                });

            migrationBuilder.CreateTable(
                name: "shippers",
                columns: table => new
                {
                    shipperID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    companyName = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shippers", x => x.shipperID);
                });

            migrationBuilder.CreateTable(
                name: "suppliers",
                columns: table => new
                {
                    supplierID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    companyName = table.Column<string>(nullable: true),
                    contactName = table.Column<string>(nullable: true),
                    contactTitle = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    region = table.Column<string>(nullable: true),
                    postalCode = table.Column<string>(nullable: true),
                    country = table.Column<string>(nullable: true),
                    fax = table.Column<string>(nullable: true),
                    homepage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_suppliers", x => x.supplierID);
                });

            migrationBuilder.CreateTable(
                name: "territories",
                columns: table => new
                {
                    territoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    regionID = table.Column<int>(nullable: false),
                    territoryDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_territories", x => x.territoryID);
                    table.ForeignKey(
                        name: "FK_territories_region_regionID",
                        column: x => x.regionID,
                        principalTable: "region",
                        principalColumn: "regionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    orderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customerID = table.Column<int>(nullable: false),
                    EmployeeID = table.Column<int>(nullable: false),
                    orderDate = table.Column<DateTime>(nullable: false),
                    requriedDate = table.Column<DateTime>(nullable: false),
                    shippedDate = table.Column<DateTime>(nullable: false),
                    shippedVia = table.Column<int>(nullable: false),
                    freight = table.Column<string>(nullable: true),
                    shipName = table.Column<string>(nullable: true),
                    shipAddress = table.Column<string>(nullable: true),
                    shipCity = table.Column<string>(nullable: true),
                    shipReigon = table.Column<string>(nullable: true),
                    shipPostalCode = table.Column<string>(nullable: true),
                    shipCountry = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.orderID);
                    table.ForeignKey(
                        name: "FK_orders_employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "employees",
                        principalColumn: "employeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orders_customers_customerID",
                        column: x => x.customerID,
                        principalTable: "customers",
                        principalColumn: "customerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orders_shippers_shippedVia",
                        column: x => x.shippedVia,
                        principalTable: "shippers",
                        principalColumn: "shipperID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    productID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryID = table.Column<int>(nullable: false),
                    supplierID = table.Column<int>(nullable: false),
                    productName = table.Column<string>(nullable: true),
                    image = table.Column<string>(nullable: true),
                    quantityPerLabel = table.Column<int>(nullable: false),
                    unitPrice = table.Column<float>(nullable: false),
                    unitsInStock = table.Column<int>(nullable: false),
                    unitsOnOrder = table.Column<int>(nullable: false),
                    recorderLevel = table.Column<int>(nullable: false),
                    discontinued = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.productID);
                    table.ForeignKey(
                        name: "FK_products_categories_categoryID",
                        column: x => x.categoryID,
                        principalTable: "categories",
                        principalColumn: "categoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_products_suppliers_supplierID",
                        column: x => x.supplierID,
                        principalTable: "suppliers",
                        principalColumn: "supplierID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "employeeteritorries",
                columns: table => new
                {
                    EmployeeTerritoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employeeID = table.Column<int>(nullable: false),
                    territoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employeeteritorries", x => x.EmployeeTerritoryID);
                    table.ForeignKey(
                        name: "FK_employeeteritorries_employees_employeeID",
                        column: x => x.employeeID,
                        principalTable: "employees",
                        principalColumn: "employeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_employeeteritorries_territories_territoryID",
                        column: x => x.territoryID,
                        principalTable: "territories",
                        principalColumn: "territoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orderdetails",
                columns: table => new
                {
                    orderDetailID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productID = table.Column<int>(nullable: false),
                    orderID = table.Column<int>(nullable: false),
                    unitPrice = table.Column<float>(nullable: false),
                    quantity = table.Column<int>(nullable: false),
                    discount = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderdetails", x => x.orderDetailID);
                    table.ForeignKey(
                        name: "FK_orderdetails_orders_orderID",
                        column: x => x.orderID,
                        principalTable: "orders",
                        principalColumn: "orderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orderdetails_products_productID",
                        column: x => x.productID,
                        principalTable: "products",
                        principalColumn: "productID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_employees_reportsTo",
                table: "employees",
                column: "reportsTo");

            migrationBuilder.CreateIndex(
                name: "IX_employeeteritorries_employeeID",
                table: "employeeteritorries",
                column: "employeeID");

            migrationBuilder.CreateIndex(
                name: "IX_employeeteritorries_territoryID",
                table: "employeeteritorries",
                column: "territoryID");

            migrationBuilder.CreateIndex(
                name: "IX_orderdetails_orderID",
                table: "orderdetails",
                column: "orderID");

            migrationBuilder.CreateIndex(
                name: "IX_orderdetails_productID",
                table: "orderdetails",
                column: "productID");

            migrationBuilder.CreateIndex(
                name: "IX_orders_EmployeeID",
                table: "orders",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_orders_customerID",
                table: "orders",
                column: "customerID");

            migrationBuilder.CreateIndex(
                name: "IX_orders_shippedVia",
                table: "orders",
                column: "shippedVia");

            migrationBuilder.CreateIndex(
                name: "IX_products_categoryID",
                table: "products",
                column: "categoryID");

            migrationBuilder.CreateIndex(
                name: "IX_products_supplierID",
                table: "products",
                column: "supplierID");

            migrationBuilder.CreateIndex(
                name: "IX_territories_regionID",
                table: "territories",
                column: "regionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employeeteritorries");

            migrationBuilder.DropTable(
                name: "orderdetails");

            migrationBuilder.DropTable(
                name: "territories");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "region");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "shippers");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "suppliers");
        }
    }
}
