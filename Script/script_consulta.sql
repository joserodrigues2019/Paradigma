/*
Consulta para atender o teste pratico da Paradigma
26/03/2021

*/

Select td.Id	    As IdDepto,
		td.Nome		As Departamento,
		tc.Nome		As Pessoa,
		tc.Salario   As Salario
From
	tColaboradores tc,
	tDepartamentos td
Where tc.DeptoId = td.Id
And   tc.Salario = (select max(Salario) from tColaboradores where tColaboradores.DeptoId = td.Id) 
Order by 1