//*****************************************************************************
//** 3043. Find the Length of the Longest Common Prefix  leetcode            **
//*****************************************************************************


struct TrieNode {
    struct TrieNode* child[10];
};

// Function to create a new Trie node
struct TrieNode* createTrieNode() {
    struct TrieNode* node = (struct TrieNode*)malloc(sizeof(struct TrieNode));
    for (int i = 0; i < 10; ++i) {
        node->child[i] = NULL;
    }
    return node;
}

// Function to insert a string into the Trie
void trieInsert(char* s, struct TrieNode* curr) {
    int idx;
    for (int i = 0; s[i] != '\0'; ++i) {
        idx = s[i] - '0';  // Convert character to index (digit)
        if (curr->child[idx] == NULL) {
            curr->child[idx] = createTrieNode();
        }
        curr = curr->child[idx];
    }
}

// Function to find the longest common prefix (LCP) using Trie
int trieMatch(char* s, struct TrieNode* curr) {
    int idx;
    int count = 0;
    for (int i = 0; s[i] != '\0'; i++) {
        idx = s[i] - '0';  // Convert character to index (digit)
        if (curr->child[idx] == NULL) {
            break;
        }
        curr = curr->child[idx];
        count++;
    }
    return count;
}

// Function to convert an integer to a string
void intToString(int num, char* str) {
    sprintf(str, "%d", num);  // Converts integer to string
}

// Function to find the longest common prefix between two arrays
int longestCommonPrefix(int* arr1, int arr1Size, int* arr2, int arr2Size) {
    struct TrieNode* root = createTrieNode();
    char curr[12];  // Buffer for storing string representation of numbers

    // Insert all numbers of arr1 in Trie
    for (int i = 0; i < arr1Size; i++) {
        intToString(arr1[i], curr);
        trieInsert(curr, root);
    }

    int maxLen = 0;

    // For every number in arr2, search LCP using Trie built from all numbers of arr1
    for (int i = 0; i < arr2Size; i++) {
        intToString(arr2[i], curr);
        int len = trieMatch(curr, root);
        if (len > maxLen) {
            maxLen = len;
        }
    }

    return maxLen;
}