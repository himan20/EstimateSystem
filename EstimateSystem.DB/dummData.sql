-- ClientMaster

Insert into ClientMaster values ('Client1')
Insert into ClientMaster values ('Client2')
Insert into ClientMaster values ('Client3')

-- BrandMaster
Insert Into BrandMaster values ('Brand1', 1)
Insert Into BrandMaster values ('Brand2', 2)
Insert Into BrandMaster values ('Brand3', 3)

-- CaptionMaster

Insert into CaptionMaster values('Caption1', 1)
Insert into CaptionMaster values('Caption2', 2)
Insert into CaptionMaster values('Caption3', 3)

-- EstimateHeader

Insert into EstimateHeader values('estNo1', GETDATE(), 'Campaign1', 'Agency1', 'PONO1', GETDATE(), 1,1, GETDATE(),GETDATE(), 80,80, 100,100,1)
Insert into EstimateHeader values('estNo2', GETDATE(), 'Campaign2', 'Agency2', 'PONO2', GETDATE(), 2,2, GETDATE(),GETDATE(), 80,80, 100,100,1)
Insert into EstimateHeader values('estNo3', GETDATE(), 'Campaign3', 'Agency3', 'PONO3', GETDATE(), 3,3, GETDATE(),GETDATE(), 80,80, 100,100,1)

-- EstimatePublication

Insert into EstimatePublication values('Publication1', 1, 'Lang1', 5, 90, 4, 100, 80, 80)
Insert into EstimatePublication values('Publication2', 2, 'Lang2', 5, 90, 4, 100, 80, 80)
Insert into EstimatePublication values('Publication3', 3, 'Lang3', 5, 90, 4, 100, 80, 80)

-- EstimateEdition

Insert into EstimateEdition values(1, 1, 'Edition1', 100, 100, 50, 50, 10, 100, 80, 80)
Insert into EstimateEdition values(2, 2, 'Edition2', 100, 100, 50, 50, 10, 100, 80, 80)
Insert into EstimateEdition values(3, 3, 'Edition3', 100, 100, 50, 50, 10, 100, 80, 80)

-- EstimateScheduled

Insert into EstimateScheduled values(1, 1, 1, GETDATE(), 1, 'Lang1', 100, 100, 50, 50, 10, 100, 80, 80)
Insert into EstimateScheduled values(2, 2, 2, GETDATE(), 2, 'Lang2', 100, 100, 50, 50, 10, 100, 80, 80)
Insert into EstimateScheduled values(3, 3, 3, GETDATE(), 3, 'Lang3', 100, 100, 50, 50, 10, 100, 80, 80)
