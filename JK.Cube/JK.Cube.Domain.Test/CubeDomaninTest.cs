using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JK.Cube.Domain.Test
{
    [TestClass]
    public class CubeDomaninTest
    {

        [TestMethod]
        public void UpdateCube()
        {
            var valueUpdate = 4;
            Models.Cube cube = new Models.Cube();
            cube.GenerateCube(2);
            var coordenate = new ValueObjects.Coordenate() { X = 2, Y = 2, Z = 2 };
            cube.Update(coordenate, valueUpdate);
            if (cube.Nodes.TryGetValue(coordenate, out long value))
            {
                Assert.IsTrue(value == valueUpdate);
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void QueryCubeCaseOne()
        {
            var valueUpdate1 = 4;
            var valueUpdate2 = 23;
            Models.Cube cube = new Models.Cube();
            cube.GenerateCube(4);
            var coordenate1 = new ValueObjects.Coordenate() { X = 2, Y = 2, Z = 2 };
            cube.Update(coordenate1, valueUpdate1);
            var coordenateQuery11 = new ValueObjects.Coordenate() { X = 1, Y = 1, Z = 1 };
            var coordenateQuery12 = new ValueObjects.Coordenate() { X = 3, Y = 3, Z = 3 };
            var valueResult1 = cube.Query(coordenateQuery11, coordenateQuery12);
            Assert.IsTrue(valueResult1 == valueUpdate1);
            var coordenate2 = new ValueObjects.Coordenate() { X = 1, Y = 1, Z = 1 };
            cube.Update(coordenate2, valueUpdate2);
            var coordenateQuery21 = new ValueObjects.Coordenate() { X = 2, Y = 2, Z = 2 };
            var coordenateQuery22 = new ValueObjects.Coordenate() { X = 4, Y = 4, Z = 4 };
            var valueResult2 = cube.Query(coordenateQuery21, coordenateQuery22);
            Assert.IsTrue(valueResult2 == valueUpdate1);
            var valueResult3 = cube.Query(coordenateQuery11, coordenateQuery12);
            Assert.IsTrue(valueResult3 == valueUpdate2 + valueUpdate1);
        }

        [TestMethod]
        public void QueryCubeCaseTwo()
        {
            var valueUpdate = 1;
            Models.Cube cube = new Models.Cube();
            cube.GenerateCube(2);
            var coordenate1 = new ValueObjects.Coordenate() { X = 2, Y = 2, Z = 2 };
            cube.Update(coordenate1, valueUpdate);
            var coordenateQuery11 = new ValueObjects.Coordenate() { X = 1, Y = 1, Z = 1 };
            var coordenateQuery12 = new ValueObjects.Coordenate() { X = 1, Y = 1, Z = 1 };
            var valueResult1 = cube.Query(coordenateQuery11, coordenateQuery12);
            Assert.IsTrue(valueResult1 == 0);
            var coordenateQuery21 = new ValueObjects.Coordenate() { X = 1, Y = 1, Z = 1 };
            var coordenateQuery22 = new ValueObjects.Coordenate() { X = 2, Y = 2, Z = 2 };
            var valueResult2 = cube.Query(coordenateQuery21, coordenateQuery22);
            Assert.IsTrue(valueResult2 == valueUpdate);
            var valueResult3 = cube.Query(coordenateQuery22, coordenateQuery22);
            Assert.IsTrue(valueResult3 == valueUpdate);
        }
    }
}
