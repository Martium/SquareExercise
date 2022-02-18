using System.Collections.Generic;
using SquareExercise.Models;

namespace SquareExercise.Service
{
    public static class CoordinatesListService
    {
        private static List<CoordinateModel> _coordinateList;

        private static List<CoordinateModel> InitializeListIfNotInitialize()
        {
            if (_coordinateList == null)
            {
                _coordinateList = new List<CoordinateModel>();
            }

            return _coordinateList;
        }

        public static List<CoordinateModel> GetAllCoordinates()
        {
            return InitializeListIfNotInitialize();
        }

        public static CoordinateModel GetSpecificCoordinate(int indexOfList)
        {
            InitializeListIfNotInitialize();

            CoordinateModel specificCoordinate;
            try
            { 
                specificCoordinate = _coordinateList[indexOfList];
            }
            catch 
            {
                specificCoordinate = null;
            }

            return specificCoordinate;
        }

        public static List<CoordinateModel> AddNewCoordinates(CoordinateModel coordinates)
        {
            InitializeListIfNotInitialize();
            _coordinateList.Add(coordinates);
            return _coordinateList;
        }

        public static int GetIndexOfSpecificCoordinates(CoordinateModel coordinates)
        {
            int indexOfList = _coordinateList.LastIndexOf(coordinates);
            return indexOfList;
        }

        public static List<CoordinateModel> AddNewCoordinatesList(List<CoordinateModel> coordinateList)
        {
            InitializeListIfNotInitialize();
            _coordinateList.AddRange(coordinateList);
            return _coordinateList;
        }


    }
}
