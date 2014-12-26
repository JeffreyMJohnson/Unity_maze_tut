/*
 * Convenience function to pass 2 ints along in single object with addition operator
 * System.Serializable allows Unity to consume this custom struct and show it in property sheet.
 */
[System.Serializable]
public struct IntVector2 {

	public int x, z;

	public IntVector2 (int x, int z) {
		this.x = x;
		this.z = z;
	}

	public static IntVector2 operator + (IntVector2 a, IntVector2 b) {
		a.x += b.x;
		a.z += b.z;
		return a;
	}
}