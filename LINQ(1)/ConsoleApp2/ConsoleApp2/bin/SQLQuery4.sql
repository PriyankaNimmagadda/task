select *from Employees
select * from Categories
select * from Products

select *from Employees where Region is not null

select c.CategoryId, c.CategoryName, p.ProductId, p.ProductName, p.UnitPrice from Categories c join Products p on c.CategoryID=p.CategoryID
select c.CategoryId, c.CategoryName, p.ProductId, p.ProductName, p.UnitPrice from Categories c ,Products p where c.CategoryID=p.CategoryID