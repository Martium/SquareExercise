using System.Collections.Generic;
using SquareExercise.Models;

namespace SquareExercise.Service
{
    public static class CoordinatesListService
    {
        private static List<PointModel> _coordinateList;

        private static List<PointModel> InitializeListIfNotInitialize()
        {
            if (_coordinateList == null)
            {
                _coordinateList = new List<PointModel>();
            }

            return _coordinateList;
        }

        public static List<PointModel> GetAllCoordinates()
        {
            return InitializeListIfNotInitialize();
        }

        public static PointModel GetSpecificCoordinate(int indexOfList)
        {
            InitializeListIfNotInitialize();

            PointModel specificPoint;
            try
            { 
                specificPoint = _coordinateList[indexOfList];
            }
            catch 
            {
                specificPoint = null;
            }

            return specificPoint;
        }

        public static List<PointModel> AddNewCoordinates(PointModel points)
        {
            InitializeListIfNotInitialize();
            _coordinateList.Add(points);
            return _coordinateList;
        }

        public static int GetIndexOfSpecificCoordinates(PointModel points)
        {
            int indexOfList = _coordinateList.LastIndexOf(points);
            return indexOfList;
        }

        public static List<PointModel> AddNewCoordinatesList(List<PointModel> coordinateList)
        {
            InitializeListIfNotInitialize();
            _coordinateList.AddRange(coordinateList);
            return _coordinateList;
        }


    }
}
