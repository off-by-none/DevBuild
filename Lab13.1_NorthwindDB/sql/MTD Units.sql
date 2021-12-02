SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED


SELECT
  tif.LoanNumber
, tif.StatusDateTime 'TI 6449 Status Date'
, pb.ProductBucket
, L.LoanPurposeID
, [Units]				=  CASE WHEN pb.ProductBucket = 'Conventional' THEN 1.75
								WHEN pb.ProductBucket = 'FHA' THEN 2.25
								WHEN pb.ProductBucket = 'VA' THEN 2
								WHEN pb.ProductBucket = 'Jumbo' THEN 2.5
								ELSE 'Problem' END
, em.FullNameFirstLast 'FSO UW'

FROM QLODS..LKWDTrackingItemFact tif
	INNER JOIN QLODS..LKWD L ON L.LoanNumber = tif.LoanNumber
	INNER JOIN QLODS..EmployeeMaster em ON em.EmployeeDimID = L.LoanUnderwriterFinalSignOffID
	INNER JOIN Reporting.dbo.vwProductBuckets pb ON pb.ProductId = L.ProductID

WHERE 1=1
	AND L.DeleteFlg = 0
	AND L.ReverseFlg = 0
	AND tif.DeleteFlg = 0
	AND tif.TrackingItemID = 6195 --TI 6449 Pre Final Sign Off Review Needed
	AND tif.StatusDtID BETWEEN 20170600 AND 20170699
	AND tif.StatusID IN (58, 100) --Completed/Confirmed, Cancelled Tracking Item
