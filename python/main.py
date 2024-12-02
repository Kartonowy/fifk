import unittest

def gcd(u, v):
    return gcd(v, u % v) if v else abs(u)

class MyTestingClass(unittest.TestCase):
    def test_upper(self):
        self.assertEqual('foo'.upper(), "FOO")
    def test_isupper(self):
        self.assertTrue("FOO".isupper())
        self.assertFalse("foo".isupper())


import pytest

@pytest.mark.parametrize("foo", [("foo")])
def test_upper(foo):
    assert foo.upper() == "FOO"

if __name__ == "__main__":
    unittest.main()
    pytest.main()
